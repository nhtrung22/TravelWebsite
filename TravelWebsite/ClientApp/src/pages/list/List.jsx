import "./list.css";
import Navbar from "../../components/navbar/Navbar";
import Header from "../../components/header/Header";
import { useLocation } from "react-router-dom";
import { useCallback, useContext, useEffect, useState } from "react";
import { format } from "date-fns";
import { DateRange } from "react-date-range";
import SearchItem from "../../components/searchItem/SearchItem";
import PropertyApiService from "../../adapters/xhr/PropertyApiService";
import { SearchContext } from "../../contexts/SearchContext";

const List = () => {
  const location = useLocation();
  const [destination, setDestination] = useState("");
  const [date, setDate] = useState(location.state.date);
  const [openDate, setOpenDate] = useState(false);
  const [options, setOptions] = useState(location.state.options);
  const [items, setItems] = useState([]);
  const [adult, setAdult] = useState(1);
  const [children, setChildren] = useState(0);
  const [maxPrice, setMaxPrice] = useState(0);
  const [minPrice, setMinPrice] = useState(0);
  const [room, setRoom] = useState(1);
  const { loading, error, dispatch } = useContext(SearchContext);

  const fetchProperties = async () => {
    let params = {
      city: destination,
      numberOfAdults: adult,
      numberOfKids: children,
      numberOfRooms: room,
      maxPrice,
      minPrice,
      fromTime: date[0].startDate,
      toTime: date[0].endDate,
    };
    let response = await PropertyApiService.getAll(params);
    if (response) {
      setItems(response.items);
    }
  };
  useEffect(() => {
    fetchProperties();
  }, []);
  return (
    <div>
      <Navbar />
      <Header type="list" />
      <div className="listContainer">
        <div className="listWrapper">
          <div className="listSearch">
            <h1 className="lsTitle">Search</h1>
            <div className="lsItem">
              <label>Destination</label>
              <input onChange={(e) => setDestination(e.target.value)} placeholder={destination} type="text" />
            </div>
            <div className="lsItem">
              <label>Check-in Date</label>
              <span onClick={() => setOpenDate(!openDate)}>{`${format(date[0].startDate, "MM/dd/yyyy")} to ${format(date[0].endDate, "MM/dd/yyyy")}`}</span>
              {openDate && <DateRange onChange={(item) => setDate([item.selection])} minDate={new Date()} ranges={date} />}
            </div>
            <div className="lsItem">
              <label>Options</label>
              <div className="lsOptions">
                <div className="lsOptionItem">
                  <span className="lsOptionText">
                    Min price <small>per night</small>
                  </span>
                  <input onChange={(value) => setMinPrice(value)} type="number" className="lsOptionInput" />
                </div>
                <div className="lsOptionItem">
                  <span className="lsOptionText">
                    Max price <small>per night</small>
                  </span>
                  <input onChange={(e) => setMaxPrice(e.target.value)} type="number" className="lsOptionInput" />
                </div>
                <div className="lsOptionItem">
                  <span className="lsOptionText">Adult</span>
                  <input onChange={(e) => setMaxPrice(e.target.value)} type="number" min={1} className="lsOptionInput" placeholder={options.adult} />
                </div>
                <div className="lsOptionItem">
                  <span className="lsOptionText">Children</span>
                  <input onChange={(value) => setChildren(value)} type="number" min={0} className="lsOptionInput" placeholder={options.children} />
                </div>
                <div className="lsOptionItem">
                  <span className="lsOptionText">Room</span>
                  <input onChange={(value) => setRoom(value)} type="number" min={1} className="lsOptionInput" placeholder={options.room} />
                </div>
              </div>
            </div>
            <button onClick={() => fetchProperties()}>Search</button>
          </div>
          <div className="listResult">
            {items &&
              items.map((item, index) => {
                return <SearchItem key={index} {...item} />;
              })}
          </div>
        </div>
      </div>
    </div>
  );
};

export default List;
