import React, { useState, useEffect } from "react";
import { CardElement, useStripe, useElements, PaymentElement, Elements, CardNumberElement } from "@stripe/react-stripe-js";
import SnackbarUtils from "../../SnackbarUtils";
import BookingApiService from "../../adapters/xhr/BookingApiService";
import { loadStripe } from "@stripe/stripe-js";
import { PaymentMethod } from "../../Constant";

export default function CheckoutForm({ clientSecret }) {
  const [succeeded, setSucceeded] = useState(false);
  const [error, setError] = useState(null);
  const [processing, setProcessing] = useState("");
  const [disabled, setDisabled] = useState(true);
  const stripe = useStripe();
  const elements = useElements();
  const id = location.pathname.split("/")[2];
  const createBooking = async () => {
    let payload = {
      fromTime: new Date(),
      toTime: new Date(),
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
      // switch (paymentIntent.status) {
      //   case "succeeded":
      //     setMessage("Payment succeeded!");
      //     break;
      //   case "processing":
      //     setMessage("Your payment is processing.");
      //     break;
      //   case "requires_payment_method":
      //     setMessage("Your payment was not successful, please try again.");
      //     break;
      //   default:
      //     setMessage("Something went wrong.");
      //     break;
      // }
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
    <form id="payment-form" onSubmit={handleSubmit}>
      <PaymentElement id="payment-element" />
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
