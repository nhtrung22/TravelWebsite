import React, { useState, useEffect } from "react";
import { CardElement, useStripe, useElements, PaymentElement, Elements, CardNumberElement } from "@stripe/react-stripe-js";
import SnackbarUtils from "../../SnackbarUtils";
import BookingApiService from "../../adapters/xhr/BookingApiService";
import { loadStripe } from "@stripe/stripe-js";
import { PaymentMethod } from "../../Constant";
import { formatDate } from "../../Utils";
import { TextField } from "@mui/material";

export default function CheckoutForm({ fromTime, toTime, clientSecret }) {
  const [succeeded, setSucceeded] = useState(false);
  const [error, setError] = useState(null);
  const [processing, setProcessing] = useState("");
  const [disabled, setDisabled] = useState(true);
  const [email, setEmail] = useState("");
  const stripe = useStripe();
  const elements = useElements();
  const id = location.pathname.split("/")[2];
  const createBooking = async () => {
    let payload = {
      fromTime: formatDate(fromTime),
      toTime: formatDate(toTime),
      propertyId: id,
      paymentMethod: PaymentMethod.Card,
    };
    let result = await BookingApiService.add(payload);
    return result;
  };

  useEffect(() => {
    if (!stripe) {
      return;
    }
    //const clientSecret = new URLSearchParams(window.location.search).get("payment_intent_client_secret");

    if (!clientSecret) {
      return;
    }

    stripe.retrievePaymentIntent(clientSecret).then(({ paymentIntent }) => {
      switch (paymentIntent.status) {
        case "succeeded":
          console.log("Payment succeeded!");
          // setMessage("Payment succeeded!");
          break;
        case "processing":
          console.log("Your payment is processing.");
          // setMessage("Your payment is processing.");
          break;
        case "requires_payment_method":
          console.log("Your payment was not successful, please try again.");
          // setMessage("Your payment was not successful, please try again.");
          break;
        default:
          console.log("Something went wrong.");
          // setMessage("Something went wrong.");
          break;
      }
    });
  }, [stripe]);

  const handleSubmit = async (ev) => {
    ev.preventDefault();
    if (!stripe || !elements) {
      // Stripe.js has not yet loaded.
      // Make sure to disable form submission until Stripe.js has loaded.
      return;
    }
    setProcessing(true);
    const payload = await stripe.confirmCardPayment(clientSecret, { receipt_email: email });
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
    <form id="payment-form" onSubmit={handleSubmit}>
      <PaymentElement id="payment-element" />
      <br />
      <TextField placeholder="Email for receipt" onChange={(e) => setEmail(e.target.value)} type="text" value={email} size="small" />
      <button className="rButton" id="submit">
        <span id="button-text">{"Pay now"}</span>
      </button>
      {/* Show any error that happens when processing the payment */}
      {/* {error && (
        <div className="card-error" role="alert">
          {error}
        </div>
      )} */}
      {/* Show a success message upon completion */}
      {/* <p className={succeeded ? "result-message" : "result-message hidden"}>
        Payment succeeded, see the result in your
        <a href={`https://dashboard.stripe.com/test/payments`}> Stripe dashboard.</a> Refresh the page to pay again.
      </p> */}
    </form>
  );
}
