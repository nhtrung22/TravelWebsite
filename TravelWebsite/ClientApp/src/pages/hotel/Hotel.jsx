import "./hotel.css";
import Navbar from "../../components/navbar/Navbar";
import Header from "../../components/header/Header";
import MailList from "../../components/mailList/MailList";
import Footer from "../../components/footer/Footer";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faCircleArrowLeft, faCircleArrowRight, faCircleXmark, faLocationDot } from "@fortawesome/free-solid-svg-icons";
import { useContext, useEffect, useState } from "react";
import PropertyApiService from "../../adapters/xhr/PropertyApiService";
import Reserve from "../../components/reserve/Reserve";
import { AuthContext } from "../../contexts/AuthContext";
import { useNavigate } from "react-router-dom";
import BookingApiService from "../../adapters/xhr/BookingApiService";
import SnackbarUtils from "../../SnackbarUtils";
import { base64ToSrc } from "../../Utils";
import { loadStripe } from "@stripe/stripe-js";
import { Elements } from "@stripe/react-stripe-js";

const stripePromise = loadStripe("pk_test_51LLMFpKay66RBQQAsEq805VONK0K7IdlBsfzr1TEoirJRtI2eh2HTLfQdpsSXTAFdC5sugqgIbNoLPkR5Tqqzr1F00wRBlRd4h", {
  locale: "en",
});

const Hotel = () => {
  const [clientSecret, setClientSecret] = useState("");
  const [slideNumber, setSlideNumber] = useState(0);
  const [open, setOpen] = useState(false);
  const [openModal, setOpenModal] = useState(false);
  const id = location.pathname.split("/")[2];
  const [hotel, setHotel] = useState({});
  const { user } = useContext(AuthContext);
  const navigate = useNavigate();
  const fetchHotel = async () => {
    let result = await PropertyApiService.getById(id);
    setHotel(result);
    if (result.images && result.images.length > 0) {
      let imgs = result.images.map((item) => ({
        src: base64ToSrc(item.file),
      }));
      setPhotos(imgs);
    }
  };

  const createPaymentIntent = (id, number) => {
    window
      .fetch("/api/payment", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ id: id, number: number == 0 ? 1 : number }),
      })
      .then((res) => {
        return res.json();
      })
      .then((data) => {
        setClientSecret(data.clientSecret);
      });
  };

  useEffect(() => {
    // Create PaymentIntent as soon as the page loads
    if (clientSecret == "") {
      createPaymentIntent(id, 1);
    }
  }, []);
  const appearance = {
    theme: "stripe",
  };
  let options = {
    clientSecret,
    appearance,
  };
  const createBooking = async () => {
    let payload = {
      fromTime: Date.now,
      toTime: Date.now,
      propertyId: id,
    };
    let result = await BookingApiService.add(payload);
    return result;
  };
  useEffect(() => {
    fetchHotel(id);
  }, []);
  const [photos, setPhotos] = useState([
    {
      src: "https://cf.bstatic.com/xdata/images/hotel/max1280x900/261707778.jpg?k=56ba0babbcbbfeb3d3e911728831dcbc390ed2cb16c51d88159f82bf751d04c6&o=&hp=1",
    },
    {
      src: "https://cf.bstatic.com/xdata/images/hotel/max1280x900/261707367.jpg?k=cbacfdeb8404af56a1a94812575d96f6b80f6740fd491d02c6fc3912a16d8757&o=&hp=1",
    },
    {
      src: "https://cf.bstatic.com/xdata/images/hotel/max1280x900/261708745.jpg?k=1aae4678d645c63e0d90cdae8127b15f1e3232d4739bdf387a6578dc3b14bdfd&o=&hp=1",
    },
    {
      src: "https://cf.bstatic.com/xdata/images/hotel/max1280x900/261707776.jpg?k=054bb3e27c9e58d3bb1110349eb5e6e24dacd53fbb0316b9e2519b2bf3c520ae&o=&hp=1",
    },
    {
      src: "https://cf.bstatic.com/xdata/images/hotel/max1280x900/261708693.jpg?k=ea210b4fa329fe302eab55dd9818c0571afba2abd2225ca3a36457f9afa74e94&o=&hp=1",
    },
    {
      src: "https://cf.bstatic.com/xdata/images/hotel/max1280x900/261707389.jpg?k=52156673f9eb6d5d99d3eed9386491a0465ce6f3b995f005ac71abc192dd5827&o=&hp=1",
    },
  ]);

  const handleClick = async () => {
    // if (user) {
    //   let result = await createBooking();
    //   if (result) {
    //     SnackbarUtils.success("success");
    //     navigate("/");
    //   }
    // } else {
    //   navigate("/login");
    // }
    if (user) {
      setOpenModal(true);
    } else {
      navigate("/login");
    }
  };

  const handleOpen = (i) => {
    setSlideNumber(i);
    setOpen(true);
  };

  const handleMove = (direction) => {
    let newSlideNumber;

    if (direction === "l") {
      newSlideNumber = slideNumber === 0 ? 5 : slideNumber - 1;
    } else {
      newSlideNumber = slideNumber === 5 ? 0 : slideNumber + 1;
    }

    setSlideNumber(newSlideNumber);
  };

  return (
    <div>
      <Navbar />
      <Header type="list" />
      <div className="hotelContainer">
        {open && (
          <div className="slider">
            <FontAwesomeIcon icon={faCircleXmark} className="close" onClick={() => setOpen(false)} />
            <FontAwesomeIcon icon={faCircleArrowLeft} className="arrow" onClick={() => handleMove("l")} />
            <div className="sliderWrapper">
              <img src={photos[slideNumber].src} alt="" className="sliderImg" />
            </div>
            <FontAwesomeIcon icon={faCircleArrowRight} className="arrow" onClick={() => handleMove("r")} />
          </div>
        )}
        <div className="hotelWrapper">
          <button className="bookNow" onClick={handleClick}>
            Reserve or Book Now!
          </button>
          <h1 className="hotelTitle">{hotel.name}</h1>
          <div className="hotelAddress">
            <FontAwesomeIcon icon={faLocationDot} />
            <span>{hotel.address}</span>
          </div>
          <span className="hotelDistance">{hotel.distance}</span>
          <span className="hotelPriceHighlight">Book a stay over $200 at this property and get a free airport taxi</span>
          <div className="hotelImages">
            {photos.map((photo, i) => (
              <div className="hotelImgWrapper" key={i}>
                <img onClick={() => handleOpen(i)} src={photo.src} alt="" className="hotelImg" />
              </div>
            ))}
          </div>
          <div className="hotelDetails">
            <div className="hotelDetailsTexts">
              <h1 className="hotelTitle">{hotel.name}</h1>
              <p className="hotelDesc">{hotel.description}</p>
            </div>
            <div className="hotelDetailsPrice">
              <h1>Perfect for a stay!</h1>
              <span>{hotel.shortDescription}</span>
              <h2>
                <b>${hotel.price}</b> (1 night)
              </h2>
              <button onClick={handleClick}>Reserve or Book Now!</button>
            </div>
          </div>
        </div>
        <MailList />
        <Footer />
      </div>
      {openModal && clientSecret && (
        <Elements
          options={{
            clientSecret,
            appearance,
          }}
          stripe={stripePromise}
        >
          <Reserve createPaymentIntent={createPaymentIntent} setOpen={setOpenModal} hotelId={id} clientSecret={clientSecret} hotel={hotel} />
        </Elements>
      )}
    </div>
  );
};

export default Hotel;
