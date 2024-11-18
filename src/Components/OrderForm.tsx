import React, { useEffect } from "react";
import { useState } from "react";
import axios from "axios";

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
  stones: Array<Stone> | undefined;
  [key: string]: any;

  constructor(
    piece: string,
    material: string,
    stones: Array<Stone> | undefined
  ) {
    this.piece = piece;
    this.material = material;
    this.stones = stones;
  }
}

function OrderForm() {
  const [stone, setStone] = useState<Stone>(new Stone("", "", undefined));
  const [jewelry, setJewelry] = useState<Jewelry>(
    new Jewelry("", "", undefined)
  );
  const [jewelryList, setJewelryList] = useState<Array<Jewelry>>([]);
  const [stoneList, setStoneList] = useState<Array<Stone>>([]);

  useEffect(() => {
    // Fetch the initial data when the component mounts
    getJewelry();
    getStones();
  }, []);

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

  const getJewelry = () => {
    axios.get("/api/jewelry")
      .then((response) => {
        setJewelryList(response.data);
      })
      .catch((error) => {
        console.error("Error fetching jewelry:", error);
      });
  };

  const getStones = () => {
    axios.get("/api/stone")
      .then((response) => {
        setStoneList(response.data);
      })
      .catch((error) => {
        console.error("Error fetching stones:", error);
      });
  };

  // Reset form data function
  const resetForm = () => {
    setStone(new Stone("", "", undefined)); // Reset stone
    setJewelry(new Jewelry("", "", undefined)); // Reset jewelry
    setJewelryList([]);
    setStoneList([]);
  };

  const handleSubmit = (e: React.MouseEvent<HTMLButtonElement>) => {
    e.preventDefault();
    // Ensure the data is valid
    if (!jewelry.piece || !jewelry.material || !stone.type || !stone.shape) {
      alert("Please fill in all the required fields.");
      return;
    }

    axios
      .post("/api/jewelry", jewelry)
      .then((response) => {
        // attaching jewelry id to stone object
        stone.jewelryId = response.data.id;
        axios
          .post("/api/stone", stone)
          .then(() => {
            getJewelry();
            getStones();
            // Reset form states to initial empty values
            setStone(new Stone("", "", undefined));
            setJewelry(new Jewelry("", "", undefined));
          })
          .catch((error) => {
            console.error("Error submitting stone:", error);
            alert("An error occurred while submitting stone data.");
          });
        resetForm();
      })
      .catch((error) => {
        console.error("Error submitting jewelry:", error);
        alert("An error occurred while submitting jewelry data.");
      });
  };

  // const getJewelry = () => {
  //   axios.get("/api/jewelry").then((response) => {
  //     setJewelryList(response.data);
  //   });
  // };

  // const getStones = () => {
  //   axios.get("/api/stone").then((response) => {
  //     setStoneList(response.data);
  //   });
  // };
  return (
    <>
      <main className="content-main">
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
            <option value="Sterling Silver">Sterling Silver</option>
            <option value="Brass">Brass</option>
            <option value="Copper">Copper</option>
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
            <option value="Lake Superior Agate">Lake Superior Agate</option>
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
          {/* submit & reset button */}
          <div>
            <button type="submit" value="Order" onClick={handleSubmit}>
              Place Order
            </button>
            <button type="button" onClick={resetForm}>
              Clear Form
            </button>
          </div>
        </form>
        {/* <pre>{JSON.stringify(jewelryList, null, 2)}</pre> */}
        {/* <pre>{JSON.stringify(stoneList, null, 2)}</pre> */}
        {jewelryList.map((jewelry) => {
          return (
            <div key={jewelry.id} style={{ border: "1px solid black" }}>
              <div>Jewelry Selection:</div>
              <p>Piece: {jewelry.piece}</p>
              <p>Material: {jewelry.material}</p>
              {/* <pre>{JSON.stringify(jewelry.stones)}</pre> */}
            </div>
          );
        })}
        {stoneList.map((stone) => {
          return (
            <>
              <div key={stone.id}>
                <div>Stone Selection:</div>
                <p>Type: {stone.type}</p>
                <p>Shape: {stone.shape}</p>
              </div>
            </>
          );
        })}
      </main>
    </>
  );
}

export default OrderForm;
