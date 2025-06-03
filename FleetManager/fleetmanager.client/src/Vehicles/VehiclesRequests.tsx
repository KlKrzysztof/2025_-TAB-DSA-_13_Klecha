import React, { CSSProperties, useState } from "react"


function VehiclesRequests() {

    var [MouseAddButton, setMouseAddButton] = useState(false)
    var [MouseDelButton, setMouseDelButton] = useState(false)
    var [text, setText] = useState("")

    const panelStyle: React.CSSProperties = {
        height: '30vh',
        width: '60vw',
        backgroundColor: '#fff',
        borderRadius: '20px',
        display: 'flex',
        justifyContent: 'flex-start',
        alignItems: 'center',
        flexDirection: 'column',
        padding: '20px'
    }

    const ListStyles: React.CSSProperties = {
        backgroundColor: '#dadada',
        width: '10vw',
        height: '25vh',
    }

    const ReservationStyle: React.CSSProperties = {
        display: "inline-flex",
        justifyContent: 'space-between',
        alignItems: 'center',
        width: '100%',
        height: '100%'
    }

    const inputStyle: React.CSSProperties = {
        height: '30px',
        width: '200px',
        fontSize: '25px',
        borderRadius: '5px',
        borderColor: '#dddddd',
        backgroundColor: '#efefef'
    }

    const TextboxStyle: CSSProperties = {
        ...inputStyle,
        width: '100%',
        minHeight: '100px',
        maxHeight: '23vh',
        height: '23vh',
        resize: 'vertical',
        padding: '10px',
        fontSize: '16px',
        lineHeight: '1.5',
        borderRadius: '8px',
        //border: '1px solid #ccc',
        boxSizing: 'border-box',
        whiteSpace: 'pre-wrap', 
        overflowWrap: 'break-word'
    }

    const ReservationsDetailsStyle: React.CSSProperties = {
        display: 'flex',
        flexDirection: 'column',
        justifyContent: 'space-between',
        alignItems: 'center',
        textAlign: 'left'
    }

    const ReserveButtonStyle: React.CSSProperties = {
        ...inputStyle,
        backgroundColor: '#36b03c',
        color: '#FFF',
        border: 'none',
        fontSize: '20px'
    }

    const ReserveButtonStyleHover: React.CSSProperties = {
        ...inputStyle,
        backgroundColor: '#26a02c',
        color: '#FFF',
        border: 'none',
        cursor: "pointer",
        fontSize: '20px'
    }

    const RefuseButtonStyle: React.CSSProperties = {
        ...inputStyle,
        backgroundColor: '#b03636',
        color: '#FFF',
        border: 'none',
        cursor: "pointer",
        fontSize: '20px'
    }

    const RefuseButtonStyleHover: React.CSSProperties = {
        ...inputStyle,
        backgroundColor: '#a02626',
        color: '#FFF',
        border: 'none',
        fontSize: '20px'
    }


    return <div style={panelStyle}>
        <h2 style={{ margin: '0' } as React.CSSProperties}>Reservations</h2>
        <div style={ReservationStyle}>
            <div style={ListStyles}>

            </div>
            <div>
                <h4 style={{ margin: '0' } as React.CSSProperties}>Description</h4>
                <textarea
                    value={text}
                    //onChange={(e) => setText(e.target.value)}
                    placeholder="Here is your description"
                    style={TextboxStyle}
                />
            </div>
            <div style={ReservationsDetailsStyle}>
                <div style={{ display: 'flex', flexDirection: 'column' } as React.CSSProperties}>
                    Name and Surname
                    <input type="text" style={inputStyle} />
                </div>
                <div style={{ display: 'flex', flexDirection: 'column' } as React.CSSProperties}>
                    Purpose
                    <input type="text" style={inputStyle} />
                </div>
                <div style={{ display: 'flex', flexDirection: 'column' } as React.CSSProperties}>
                    Planed start - end date
                    <input type="text" style={inputStyle} />
                </div>
                <div style={{ display: 'flex', flexDirection: 'column' } as React.CSSProperties}>
                    factual start - end date
                    <input type="text" style={inputStyle} />
                </div>
                <div style={{ display: 'flex', flexDirection: 'row', justifyContent: 'space-around', marginTop: '10px' } as React.CSSProperties}>
                    <input type="button" value="Reserve" style={MouseAddButton ? ReserveButtonStyleHover : ReserveButtonStyle} onMouseEnter={() => setMouseAddButton(true)} onMouseLeave={() => setMouseAddButton(false)} />
                    <input type="button" value="Refuse" style={MouseDelButton ? RefuseButtonStyleHover : RefuseButtonStyle} onMouseEnter={() => setMouseDelButton(true)} onMouseLeave={() => setMouseDelButton(false)} />
                </div>
            </div>
        </div>
    </div>
}

export default VehiclesRequests