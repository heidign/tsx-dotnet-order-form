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

  // onChange of jewelry select
  const handleJewelryChange = (
    e: React.ChangeEvent<HTMLSelectElement>,
    key: string
  ) => {
    const selectKey = key as keyof typeof jewelry;
    setJewelry({ ...jewelry, [selectKey]: e.target.value });
  };

  // onChange of stone select
  const handleStoneChange = (
    e: React.ChangeEvent<HTMLSelectElement>,
    key: string
  ) => {
    const selectKey = key as keyof typeof stone;
    setStone({ ...stone, [selectKey]: e.target.value });
  };

  const handleSubmit = (e: React.MouseEvent<HTMLButtonElement>) => {
    e.preventDefault();
    console.log("clicked", handleSubmit);
  };

  return (
    <>
      <form>
        {/* jewelry piece */}
        <select
          className={"form-control col-md-2 mr-2"}
          value={jewelry.piece}
          onChange={(e) => {
            handleJewelryChange(e, "piece");
          }}
        >
          <option value="" disabled>
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
          onChange={(e) => {
            handleJewelryChange(e, "material");
          }}
        >
          <option value="" disabled>
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
          onChange={(e) => {
            handleStoneChange(e, "type");
          }}
        >
          <option value="" disabled>
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
          onChange={(e) => {
            handleStoneChange(e, "shape");
          }}
        >
          <option value="" disabled>
            Stone Shape
          </option>
          <option value="Oval">Oval</option>
          <option value="Round">Round</option>
          <option value="Drop">Drop</option>
          <option value="LargeDrop">Large Drop</option>
          <option value="Trapezoid">Trapezoid</option>
          <option value="SurpriseMe">Surprise Me</option>
        </select>
        {/* submit button */}
        <div>
          <button type="submit" value="Order" onClick={handleSubmit}>
            Place Order
          </button>
        </div>
      </form>
    </>
  );
}

export default OrderForm;
