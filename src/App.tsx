import React from "react";
import logo from "./logo.svg";
// import { Counter } from './features/counter/Counter';
import "./App.css";
import OrderForm from "./Components/OrderForm";

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <p>Jewelry Form</p>
      </header>
      <span>
        <OrderForm />
      </span>
    </div>
  );
}

export default App;
