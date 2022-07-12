import { Link } from "react-router-dom";
import { base64ToSrc } from "../../Utils";
import "./searchItem.css";

const SearchItem = (props) => {
  return (
    <div className="searchItem">
      <img
        src={
          props.images && props.images.length > 0
            ? base64ToSrc(props.images[0].file)
            : "https://cf.bstatic.com/xdata/images/hotel/square600/261707778.webp?k=fa6b6128468ec15e81f7d076b6f2473fa3a80c255582f155cae35f9edbffdd78&o=&s=1"
        }
        alt=""
        className="siImg"
      />
      <div className="siDesc">
        <h1 className="siTitle">{props.name}</h1>
        {/* <span className="siDistance">500m from center</span> */}
        <span className="siCityOp">{props.city.name}</span>
        <span className="siType">{props.type.name}</span>
        <span className="siFeatures">{props.shortDescription}</span>
        <span className="siCancelOp">Free cancellation </span>
        <span className="siCancelOpSubtitle">You can cancel later, so lock in this great price today!</span>
      </div>
      <div className="siDetails">
        <div className="siRating">
          {/* <span>Excellent</span> */}
          {/* <button>8.9</button> */}
        </div>
        <div className="siDetailTexts">
          <span className="siPrice">${props.price}</span>
          <span className="siTaxOp">Includes taxes and fees</span>
          <Link to={`/hotels/${props.id}`}>
            <button className="siCheckButton">See availability</button>
          </Link>
        </div>
      </div>
    </div>
  );
};

export default SearchItem;
