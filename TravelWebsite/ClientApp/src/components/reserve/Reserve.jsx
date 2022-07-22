import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faCircleXmark } from "@fortawesome/free-solid-svg-icons";
import "./reserve.css";
import { useContext, useEffect, useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import { SearchContext } from "../../contexts/SearchContext";
import CheckoutForm from "./CheckoutForm";
import { format } from "date-fns";
import { loadStripe } from "@stripe/stripe-js";
import { Elements, PaymentElement, useElements, useStripe } from "@stripe/react-stripe-js";
import BookingApiService from "../../adapters/xhr/BookingApiService";
import SnackbarUtils from "../../SnackbarUtils";
import { DateRange } from "react-date-range";
import { ClickAwayListener } from "@mui/material";
import { formatDate } from "../../Utils";

const Reserve = ({ setOpen, hotelId, clientSecret, hotel, createPaymentIntent }) => {
  const [paymentMethod, setPaymentMethod] = useState(1);
  const [selectedRooms, setSelectedRooms] = useState([]);
  const [succeeded, setSucceeded] = useState(false);
  const [error, setError] = useState(null);
  const [processing, setProcessing] = useState("");
  const [disabled, setDisabled] = useState(true);
  const stripe = useStripe();
  const elements = useElements();
  const id = location.pathname.split("/")[2];
  const { loading, dispatch, dates } = useContext(SearchContext);
  const [openDate, setOpenDate] = useState(false);
  const [date, setDate] = useState([
    {
      startDate: new Date(),
      endDate: new Date(),
      key: "selection",
    },
  ]);
  const createBooking = async () => {
    let payload = {
      fromTime: formatDate(date[0].startDate),
      toTime: formatDate(date[0].endDate),
      propertyId: id,
      paymentMethod: paymentMethod,
    };
    let result = await BookingApiService.add(payload);
    return result;
  };
  // const { data, loading, error } = useFetch(`/hotels/room/${hotelId}`);

  const getDatesInRange = (startDate, endDate) => {
    const start = new Date(startDate);
    const end = new Date(endDate);

    const date = new Date(start.getTime());

    const dates = [];

    while (date <= end) {
      dates.push(new Date(date).getTime());
      date.setDate(date.getDate() + 1);
    }

    return dates;
  };

  // const alldates = getDatesInRange(dates[0].startDate, dates[0].endDate);

  // const isAvailable = (roomNumber) => {
  //   const isFound = roomNumber.unavailableDates.some((date) => alldates.includes(new Date(date).getTime()));

  //   return !isFound;
  // };

  const handleSelect = (e) => {
    const checked = e.target.checked;
    const value = e.target.value;
    setSelectedRooms(checked ? [...selectedRooms, value] : selectedRooms.filter((item) => item !== value));
  };

  const navigate = useNavigate();

  const handleClick = async () => {
    try {
      await Promise.all(
        selectedRooms.map((roomId) => {
          const res = axios.put(`/rooms/availability/${roomId}`, {
            dates: alldates,
          });
          return res.data;
        })
      );
      setOpen(false);
      navigate("/");
    } catch (err) {}
  };
  const handleSubmit = async (ev) => {
    ev.preventDefault();
    setProcessing(true);
    let result = await createBooking();
    if (result) {
      SnackbarUtils.success("success");
      setError(null);
      setProcessing(false);
      setSucceeded(true);
    }
  };
  function parseDate(str) {
    var mdy = str.split("/");
    return new Date(mdy[2], mdy[0] - 1, mdy[1]);
  }

  function datediff(first, second) {
    // Take the difference between the dates and divide by milliseconds per day.
    // Round to nearest whole number to deal with DST.
    return Math.round((second.getTime() - first.getTime()) / (1000 * 60 * 60 * 24));
  }
  useEffect(() => {
    createPaymentIntent(id, datediff(new Date(date[0].startDate), new Date(date[0].endDate)));
  }, [date[0].startDate, date[0].endDate]);
  return (
    <div className="reserve">
      <div className="rContainer">
        <FontAwesomeIcon icon={faCircleXmark} className="rClose" onClick={() => setOpen(false)} />
        <ClickAwayListener onClickAway={() => setOpenDate(false)}>
          <div className="product-info">
            <h3 className="product-title">{hotel.name}</h3>
            <br />
            <h4 className="product-price">${hotel.price} / night</h4>
            <br />
            <h4 className="product-date" onClick={() => setOpenDate(!openDate)}>{`${format(date[0].startDate, "MM/dd/yyyy")} to ${format(
              date[0].endDate,
              "MM/dd/yyyy"
            )}`}</h4>
            {openDate && (
              <DateRange
                editableDateInputs={true}
                onChange={(item) => setDate([item.selection])}
                moveRangeOnFirstSelection={false}
                ranges={date}
                className="date"
                minDate={new Date()}
              />
            )}
            <br />
          </div>
        </ClickAwayListener>
        <input type="checkbox" id="card" name="card" value={1} checked={paymentMethod == 1} onChange={(e) => setPaymentMethod(e.target.value)} />
        <label htmlFor="card"> Card</label>
        <br />
        <input
          type="checkbox"
          id="payuponcheckin"
          name="payuponcheckin"
          value={2}
          checked={paymentMethod == 2}
          onChange={(e) => setPaymentMethod(e.target.value)}
        />
        <label htmlFor="payuponcheckin"> Pay upon check-in</label>
        <br />
        <br />
        {paymentMethod == 1 ? (
          <CheckoutForm fromTime={date[0].startDate} toTime={date[0].endDate} clientSecret={clientSecret} />
        ) : (
          <button onClick={handleSubmit} className="rButton">
            Reserve Now!
          </button>
        )}
        {/* <span>Select your rooms:</span> */}
        {/* {data.map((item) => (
          <div className="rItem" key={item._id}>
            <div className="rItemInfo">
              <div className="rTitle">{item.title}</div>
              <div className="rDesc">{item.desc}</div>
              <div className="rMax">
                Max people: <b>{item.maxPeople}</b>
              </div>
              <div className="rPrice">{item.price}</div>
            </div>
            <div className="rSelectRooms">
              {item.roomNumbers.map((roomNumber) => (
                <div className="room">
                  <label>{roomNumber.number}</label>
                  <input type="checkbox" value={roomNumber._id} onChange={handleSelect} disabled={!isAvailable(roomNumber)} />
                </div>
              ))}
            </div>
          </div>
        ))} */}
      </div>
    </div>
  );
};

export default Reserve;
