import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faCircleXmark } from "@fortawesome/free-solid-svg-icons";
import "./reserve.css";
import { useContext, useEffect, useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import { SearchContext } from "../../contexts/SearchContext";
import CheckoutForm from "./CheckoutForm";
import { loadStripe } from "@stripe/stripe-js";
import { Elements, PaymentElement, useElements, useStripe } from "@stripe/react-stripe-js";
import BookingApiService from "../../adapters/xhr/BookingApiService";

const Reserve = ({ setOpen, hotelId, clientSecret, hotel }) => {
  const [selectedRooms, setSelectedRooms] = useState([]);
  const [succeeded, setSucceeded] = useState(false);
  const [error, setError] = useState(null);
  const [processing, setProcessing] = useState("");
  const [disabled, setDisabled] = useState(true);
  const stripe = useStripe();
  const elements = useElements();
  const id = location.pathname.split("/")[2];
  const { loading, dispatch, dates } = useContext(SearchContext);
  const createBooking = async () => {
    let payload = {
      fromTime: Date.now,
      toTime: Date.now,
      propertyId: id,
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
    if (!stripe || !elements) {
      // Stripe.js has not yet loaded.
      // Make sure to disable form submission until Stripe.js has loaded.
      return;
    }
    setProcessing(true);
    const payload = await stripe.confirmPayment({
      elements,
      confirmParams: {
        // Make sure to change this to your payment completion page
        return_url: "http://localhost:44333",
      },
      redirect: "if_required",
    });
    if (payload.error) {
      setError(`Payment failed ${payload.error.message}`);
      setProcessing(false);
    } else {
      let result = await createBooking();
      if (result) {
        SnackbarUtils.success("success");
        setError(null);
        setProcessing(false);
        setSucceeded(true);
      }
    }
  };
  return (
    <div className="reserve">
      <div className="rContainer">
        <FontAwesomeIcon icon={faCircleXmark} className="rClose" onClick={() => setOpen(false)} />
        <div className="product-info">
          <h3 className="product-title">{hotel.name}</h3>
          <br />
          <h4 className="product-price">${hotel.price} / night</h4>
          <br />
          <h4 className="product-date">{new Date().toISOString().slice(0, 10)}</h4>
          <br />
        </div>
        <CheckoutForm clientSecret={clientSecret} />
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
        {/* <button onClick={handleClick} className="rButton">
          Reserve Now!
        </button> */}
      </div>
    </div>
  );
};

export default Reserve;
