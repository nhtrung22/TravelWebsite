import React, { Component } from "react";
import MyContext from "./MyContext";

export default class MyProvider extends Component {
  constructor(props) {
    super(props);
    this.state = this.getInitialState();
  }

  getInitialState = () => ({});

  resetState = () => {
    this.setState(this.getInitialState());
  };

  render() {
    return (
      <MyContext.Provider
        value={{
          resetState: () => {
            this.resetState();
          },
        }}
      >
        {this.props.children}
      </MyContext.Provider>
    );
  }
}
