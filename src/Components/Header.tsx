import React from "react";

type Props = {
    title: string,
}

function Header({title} : Props) {

    return (
        <>
            <h2>{title}</h2>
        </>
    );
}

export default Header;
