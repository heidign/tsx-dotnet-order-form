import React from "react";
import "./App.css";
import OrderForm from "./Components/OrderForm";

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <h1>Jewelry Form</h1>
      </header>
      <div>
        <OrderForm />
      </div>
    </div>
  );
}

export default App;
