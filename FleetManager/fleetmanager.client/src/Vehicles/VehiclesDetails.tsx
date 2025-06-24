import { useEffect, useState} from "react"


interface getVehicle {
    id: Number | null | undefined
}

function VehiclesDetails({ id }: getVehicle) { 

    var [MouseAddButton, setMouseAddButton] = useState(false)
    var [MouseDelButton, setMouseDelButton] = useState(false)
    var [MouseModButton, setMouseModButton] = useState(false)

    var [canModify, setCanModify] = useState(false)

    var [PlateNr, setPlateNr] = useState("")
    var [Purpose, setPurpose] = useState("")
    var [TotalMileage, setTotalMileage] = useState("")
    var [Outfit, setOutfit] = useState([])
    var [Overseerer, setOverseerer] = useState("")
    var [Serviced, setServiced] = useState(false)
    var [Vehicle, setVehicle] = useState("")
    var [Vin, setVin] = useState("")
    var [vehiclePurposeId, setVehiclePurposeId] = useState(0)
    var [employeeId, setEmployeeId] = useState(0)
    var [newEmployee, setNewEmployee] = useState(0)
    var [modelId, setModelId] = useState(0)

    var [OutfittingOptions, setOutfittingOption] = useState([])
    var [PurposeOptions, setPurposeOptions] = useState([])
    var [OverseererOptions, setOverseererOptions] = useState([])

    var [showOutfittingOptions, setshowOutfittingOptions] = useState(false)
    var [showPurposeOptions, setShowPurposeOptions] = useState(false)
    var [showOverseererOptions, setshowOverseererOptions] = useState(false)

    var [purposeListHandler, setPurposeListHandler] = useState([false])
    var [outfittingListHandler, setOutfittingListHandler] = useState([false])
    var [overseererListHandler, setOverseererListHandler] = useState([false])

    var [PurposeOptionsHover, setPurposeOptionsHover] = useState(false)
    var [overseererOptionsHover, setOvereererOptionsHover] = useState(false)


    const handleModifyVehicle = async (id: number | null) => {

        if (canModify) {

            const purposeExist = PurposeOptions.some(p => p.name == Purpose)

            var puprId = vehiclePurposeId

            if (!purposeExist) {
                await fetch(`/api/vehicle/purpose/create/`, {
                    method: "PUT",
                    headers: {
                        'Content-type': 'application/json'
                    },
                    body: JSON.stringify({
                        vehiclePurposeId: 0,
                        name: Purpose
                    })
                })
                setVehiclePurposeId(PurposeOptions.length + 1)
                puprId = PurposeOptions.length + 1
            }

            if (employeeId != newEmployee) {
                const z = await fetch(`/api/caretake/patch/employee/id/${newEmployee}/vehicle/id/${id}/`, {
                    method: "PATCH",
                    headers: {
                        'Content-type': 'application/json'
                    }
                })
            }

            await fetch(`/api/vehicle/vehicle/update/`, {
                method: "POST",
                headers: {
                    'Content-type': 'application/json'
                },
                body: JSON.stringify({
                    vehicleId: Number(id),
                    totalMileage: Number(TotalMileage),
                    isInService: Boolean(Serviced),
                    vehiclePurposeId: puprId,
                    plateNumber: PlateNr,
                    modelId: modelId,
                    vin: Vin
                })
            })

            window.location.reload()
        }

        setCanModify(!canModify)
    }

    const handleAddVehicle = async () => {
        await fetch("/api/vehicle/vehicle/create", {
            method: "PUT",
            headers: {
                'Content-type': 'application/json'
            },
            body: JSON.stringify({
                vehicleId: 10,
                totalMileage: 0,
                isInService: false,
                vehiclePurposeId: 1,
                plateNumber: "string",
                modelId: 1,
                vin: "string"
            })
        })

        window.location.reload()
    }

    const handleDeleteVehicle = async (id: number | null) => {
        if (id == null) {
            window.alert("Choose vehicle you want to delete!")
            return
        } 
        if (window.confirm("Do you want to delete a vehicle?")) { 
            const response = await fetch(`/api/vehicle/vehicle/delete/id/${id}`, {
                method: "DELETE"
            })

            if (response.ok) {
                window.alert("Vehicle deleted")
            } else {
                console.error('Cannot delete vehicle', response.status);
            }
        }

        window.location.reload();
    }

    useEffect(() => {
        const handleGetData = async (id: Number | null | undefined) => {
            if (id == null || id == undefined)
                return

            const response = await fetch("/api/vehicle/vehicle/details/id/" + id)
            const json: JSON = await response.json()

            const {
                vehicleId,
                vehicle,
                vehicleModel,
                vehicleManufacturer,
                vehicleOutfitting,
                vehiclePurpose,
                vehicleVersion
            } = json;

            const {
                _,
                totalMileage,
                isInService,
                vehiclePurposeId,
                plateNumber,
                modelId,
                vin
            } = vehicle

            setPlateNr(plateNumber)

            setOutfit(vehicleOutfitting)

            setVin(vehicle.vin)

            setVehicle(`${vehicleManufacturer.name} ${vehicleVersion.name}`)
            
            setTotalMileage(totalMileage)
            
            setServiced(isInService)

            setPurpose(vehiclePurpose.name)

            setVehiclePurposeId(vehiclePurposeId)

            setModelId(modelId)

            try {
                const overseererCareTake = await fetch("/api/caretake/get/vehicle/id/" + vehicleId).then(res => res.json())

                const overseerer = await fetch("api/employee/get/id/" + overseererCareTake.employeeId).then(res => res.json())

                setOverseerer(`${overseerer.firstName} ${overseerer.surname}`)
                setEmployeeId(overseerer.employeeId)
                setNewEmployee(overseerer.employeeId)
            }
            catch (ex) {
                setOverseerer("Not available")
            }
        }
        handleGetData(id)

        const handleGetOptions = async () => {
            const resultOut = await fetch("/api/vehicle/outfitting/all").then(res => res.json())

            setOutfittingOption(resultOut)

            setOutfittingListHandler(Array(resultOut.length).fill(false))

            const resultPurp = await fetch("/api/vehicle/purpose/all").then(res => res.json())

            setPurposeOptions(resultPurp)

            setPurposeListHandler(Array(resultPurp.length).fill(false))

            const resultEmp = await fetch("/api/employee/get/all").then(res => res.json())

            setOverseererOptions(resultEmp)

            setOverseererListHandler(Array(resultEmp.length).fill(false))
        }
        handleGetOptions()

    }, [id])

    const setPurposeHover = (id: number) => {
        var arr = Array(purposeListHandler.length).fill(false)

        arr[id] = true

        setPurposeListHandler(arr)
    }

    const setOnCLickPurpose = () => {
        for (let i = 0; i < purposeListHandler.length; i++) {
            if (purposeListHandler[i] == true) {
                setVehiclePurposeId(PurposeOptions[i-1].vehiclePurposeId)
                setPurpose(PurposeOptions[i-1].name)
            }
        }
    }

    const setOverseererHover = (id: number) => {
        var arr = Array(overseererListHandler.length).fill(false)

        arr[id] = true

        setOverseererListHandler(arr)
    }

    const setOnCLickOverseerer = () => {
        for (let i = 1; i <= overseererListHandler.length; i++) {
            if (overseererListHandler[i] == true) {
                setNewEmployee(OverseererOptions[i-1].employeeId)
                setOverseerer(`${OverseererOptions[i-1].firstName} ${OverseererOptions[i-1].surname}`)
            }
        }
    }

    const panelStyle: React.CSSProperties = {
        height: '45vh',
        width: '30vw',
        backgroundColor: '#fff',
        //borderRadius: '0 20px 20px 0',
        display: 'flex',
        justifyContent: 'flex-start',
        alignItems: 'center',
        flexDirection: 'column',
        padding: '20px'
    }

    const rowStyle: React.CSSProperties = {
        display: 'flex',
        justifyContent: 'space-between',
        alignItems: 'flex-start',
        flexDirection: 'column',
        textAlign: "left",
        height: '100%',
        width: '50%'
    }

    const wraperStyle: React.CSSProperties = {
        height: '100%',
        width: '100%',
        display: 'flex',
        justifyContent: 'space-between',
        alignItems: 'center',
        flexDirection: 'row'
    }

    const nameInputStyle: React.CSSProperties = {
        height: '50px',
        width: '350px',
        fontSize: '45px',
        borderRadius: '5px',
        borderColor: '#dddddd',
        backgroundColor: '#efefef'
    }

    const inputStyle: React.CSSProperties = {
        height: '30px',
        width: '200px',
        fontSize: '25px',
        borderRadius: '5px',
        borderColor: '#dddddd',
        backgroundColor: '#efefef'
    }

    const checkboxStyle: React.CSSProperties = {
        height: '30px',
        width: '30px',
        borderRadius: '5px',
        borderColor: '#dddddd',
        backgroundColor: '#efefef',
        cursor: 'pointer'
    }

    const inputWraperStyle: React.CSSProperties = {
        display: 'flex',
        flexDirection: 'column',
        justifyContent: 'flex-start'
    }

    const addButtonStyle: React.CSSProperties = {
        ...inputStyle,
        backgroundColor: '#36b03c',
        color: '#FFF',
        border: 'none',
        fontSize: '20px'
    }

    const addButtonStyleHover: React.CSSProperties = {
        ...inputStyle,
        backgroundColor: '#26a02c',
        color: '#FFF',
        border: 'none',
        cursor: "pointer",
        fontSize: '20px'
    }

    const deleteButtonStyle: React.CSSProperties = {
        ...inputStyle,
        backgroundColor: '#b03636',
        color: '#FFF',
        border: 'none',
        cursor: "pointer",
        fontSize: '20px'
    }

    const deleteButtonStyleHover: React.CSSProperties = {
        ...inputStyle,
        backgroundColor: '#a02626',
        color: '#FFF',
        border: 'none',
        fontSize: '20px',
        cursor: "pointer"
    }

    const modifyButtonStyle: React.CSSProperties = {
        ...inputStyle,
        backgroundColor: '#F8B117',
        color: '#FFF',
        border: 'none',
        cursor: "pointer",
        fontSize: '20px'
    }

    const modifyButtonStyleHover: React.CSSProperties = {
        ...inputStyle,
        backgroundColor: '#D79C1E',
        color: '#FFF',
        border: 'none',
        cursor: "pointer",
        fontSize: '20px'
    }

    const listStyle = {
        position: "relative",
        top: "0",
        left: "0",
        right: "0",
        zIndex: '1000',
        background: 'white',
        border: '1px solid #ccc',
        borderTop: 'none',
        maxHeight: '200px',
        overflowY: 'auto',
        listStyle: 'none',
        padding: '0',
        margin: '0',
        boxShadow: '0 4px 8px rgba(0,0,0,0.1)'
    } as React.CSSProperties

    return <div style={panelStyle} >
        <input style={nameInputStyle} type="text" value={Vehicle} onChange={canModify ? (e) => setVehicle(e.target.value) : undefined}></input>
        <div style={wraperStyle }>
            <div style={rowStyle}>
                <div style={inputWraperStyle}>
                    Plate number
                    <input type="text" style={inputStyle} value={PlateNr} onChange={canModify ? (e) => setPlateNr(e.target.value) : undefined} />
                </div>
                <div style={inputWraperStyle}>
                    Puropse
                    <input type="text" style={inputStyle} value={Purpose} onChange={canModify ? (e) => setPurpose(e.target.value) : undefined} onClick={canModify ? () => setShowPurposeOptions(true) : undefined} onBlur={canModify ? () => setShowPurposeOptions(false) : undefined}></input>
                    {
                        showPurposeOptions || PurposeOptionsHover ? <ul style={listStyle} onMouseEnter={() => { setPurposeOptionsHover(true) }} onMouseLeave={() => { setPurposeOptionsHover(false) } }>
                            {PurposeOptions.map(p => (
                                <li key={p.vehiclePurposeId} style={!purposeListHandler[p.vehiclePurposeId] ? { cursor: "pointer" } : { cursor: "pointer", backgroundColor: "#cacaca" }} onMouseEnter={() => setPurposeHover(p.vehiclePurposeId)} onClick={() => setOnCLickPurpose() }>{p.name}</li>
                            ))}
                        </ul>
                        : undefined
                    }
                </div>
                <div style={inputWraperStyle}>
                    Total mileage
                    <input type="text" style={inputStyle} value={TotalMileage} onChange={canModify ? (e) => setTotalMileage(e.target.value) : undefined}></input>
                </div>
            </div>
            <div style={rowStyle}>
                <div style={inputWraperStyle}>
                    Vin
                    <input type="text" style={inputStyle} value={Vin} onChange={canModify ? (e) => setVin(e.target.value) : undefined}></input>
                </div>
                <div style={inputWraperStyle}>
                    Overseerer
                    <input type="text" style={inputStyle} value={Overseerer} onChange={canModify ? (e) => setOverseerer(e.target.value) : undefined} onClick={canModify ? () => setshowOverseererOptions(true) : undefined} onBlur={canModify ? () => setshowOverseererOptions(false) : undefined}></input>
                    {
                        showOverseererOptions || overseererOptionsHover ? <ul style={listStyle} onMouseEnter={() => { setOvereererOptionsHover(true) }} onMouseLeave={() => { setOvereererOptionsHover(false) }}>
                            {OverseererOptions.map(o => (
                                <li key={o.employeeId} style={!overseererListHandler[o.employeeId] ? { cursor: "pointer" } : { cursor: "pointer", backgroundColor: "#cacaca" }} onMouseEnter={() => setOverseererHover(o.employeeId)} onClick={() => setOnCLickOverseerer()}>{`${o.firstName} ${o.surname}`}</li>
                            ))}
                        </ul>
                            : undefined
                    }
                </div>
                <div style={inputWraperStyle}>
                    Serviced
                    <input type="checkbox" style={checkboxStyle} checked={Serviced}></input>
                </div>
            </div>
        </div>
        <div style={{ ...wraperStyle, justifyContent: 'space-around' }}>
            <input type="button" value="Add Vehicle" style={MouseAddButton ? addButtonStyleHover : addButtonStyle} onMouseEnter={() => setMouseAddButton(true)} onMouseLeave={() => setMouseAddButton(false)} onClick={ () => handleAddVehicle()} />
            <input type="button" value="Delete Vehicle" style={MouseDelButton ? deleteButtonStyleHover : deleteButtonStyle} onMouseEnter={() => setMouseDelButton(true)} onMouseLeave={() => setMouseDelButton(false)} onClick={() => handleDeleteVehicle(id)} />
            <input type="button" value={canModify ? "Save changes" : "Modify Vehicle"} style={MouseModButton ? modifyButtonStyleHover : modifyButtonStyle} onMouseEnter={() => setMouseModButton(true)} onMouseLeave={() => setMouseModButton(false)} onClick={() => handleModifyVehicle(id)} />
        </div>
    </div>
}

export default VehiclesDetails