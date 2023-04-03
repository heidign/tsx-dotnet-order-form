import React from "react";
import { useState } from "react";

class Stone {
  type: string;
  shape: string;
  jewelryId: number | undefined;
  [key: string]: any;

  constructor(type: string, shape: string, jewelryId: number | undefined) {
    this.type = type;
    this.shape = shape;
    this.jewelryId = jewelryId;
  }
}

class Jewelry {
  piece: string;
  material: string;
  [key: string]: any;

  constructor(piece: string, material: string) {
    this.piece = piece;
    this.material = material;
  }
}

function OrderForm() {
  const [stone, setStone] = useState<Stone>(new Stone("", "", undefined));
  const [jewelry, setJewelry] = useState<Jewelry>(new Jewelry("", ""));

  // onChange
  const handleChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
    // setValues({ ...values, [e.target.name]: e.target.value });
  };

  return (
    <>
      <form>
        {/* <label htmlFor=""></label> */}
        {/* jewelry piece */}
        <select
          className={"form-control col-md-2 mr-2"}
          value={jewelry.piece}
          onChange={(e) => {
            jewelry.piece = e.target.value;
            setJewelry(jewelry);
          }}
        >
          <option value="" disabled selected>
            Jewelry Piece
          </option>
          <option value="Ring">Ring</option>
          <option value="Pendant">Pendant</option>
          <option value="Cuff">Cuff</option>
        </select>
        {/* material */}
        <select
          className={"form-control col-md-2 mr-2"}
          value={jewelry.material}
          onChange={(e) => (jewelry.material = e.target.value)}
        >
          <option value="" disabled selected>
            Material
          </option>
          <option value="SterlingSilver">Sterling Silver</option>
          <option value="Brass">Brass</option>
          <option value="Copper">Copper</option>
          <option value=""></option>
        </select>
        {/* stone type */}
        <select
          className={"form-control col-md-2 mr-2"}
          value={stone.type}
          onChange={(e) => (stone.shape = e.target.value)}
        >
          <option value="" disabled selected>
            Stone Type
          </option>
          <option value="Amethyst">Amethyst</option>
          <option value="LapisLazuli">Lapis Lazuli</option>
          <option value="Malachite">Malachite</option>
          <option value="LakeSuperiorAgate">Lake Superior Agate</option>
          <option value="BlackAgate_Onyx">Black Agate / Onyx</option>
          <option value="SurpriseMe">Surprise Me</option>
        </select>
        {/* stone shape */}
        <select
          className={"form-control col-md-2 mr-2"}
          value={stone.shape}
          onChange={(e) => (stone.shape = e.target.value)}
        >
          <option value="" disabled selected>
            Stone Shape
          </option>
          <option value="Oval">Oval</option>
          <option value="Round">Round</option>
          <option value="Drop">Drop</option>
          <option value="LargeDrop">Large Drop</option>
          <option value="Trapezoid">Trapezoid</option>
          <option value="SurpriseMe">Surprise Me</option>
        </select>

        <button>Submit</button>
      </form>
    </>
  );
}

export default OrderForm;
