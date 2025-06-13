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
    var [Outfit, setOutfit] = useState("")
    var [Overseerer, setOverseerer] = useState("")
    var [Serviced, setServiced] = useState(false)
    var [Vehicle, setVehicle] = useState("")

    const handleModifyVehicle = async (id: number | null) => {

        if (canModify) {
            fetch(`/api/vehicle/vehicle/update/`, {
                method: "POST",
                headers: {
                    'Content-type': 'application/json'
                },
                body: JSON.stringify({
                    vehicleId: Number(id),
                    totalMileage: Number(TotalMileage),
                    isInService: Boolean(Serviced),
                    vehiclePurposeId: 1,//Purpose,
                    plateNumber: PlateNr,
                    modelId: 1,
                    vin: "420"
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

            const response = await fetch("/api/vehicle/vehicle/id/" + id)
            const json: JSON = await response.json()

            const {
                vehicleId,
                totalMileage,
                isInService,
                vehiclePurposeId,
                plateNumber,
                modelId,
                vin
            } = json;

            setPlateNr(plateNumber)
            setOutfit("")

            try {
                await fetch("/api/vehicle/purpose/id/" + vehiclePurposeId).then(res => res.json()).then(data => setPurpose(data.name))
            }
            catch (ex) {
                setPurpose("Not available")
            }
            try {
                await fetch("/api/vehicle/model/id/" + modelId).then(res => res.json()).then(async data => {
                    const Manufacturer = await fetch("/api/vehicle/manufacturer/id/" + data.manufacturerId).then(res => res.json())
                    const Version = await fetch("/api/vehicle/version/id/" + data.vehicleVersionId).then(res => res.json())

                    const Outfits = await fetch("/api/vehicle/outfitting/all" + data.vehicleVersionId).then(res => res.json())
                    /*const OutfitsArray
                    Outfits*/

                    setVehicle(String(Manufacturer.name + Version.name))
                    setOutfit(Outfit)
                })
            }
            catch (ex) {
                setVehicle("Not available")
            }
            
            setTotalMileage(totalMileage)
            
            setServiced(isInService)
        }
        handleGetData(id)
    }, [id])

    useEffect(() => {
        const handleGetData = async (id: Number | null | undefined) => {
            if (id == null || id == undefined)
                return

            const response = await fetch("/api/vehicle/vehicle/id/" + id)
            const json: JSON = await response.json()

            const {
                vehicleId,
                totalMileage,
                isInService,
                vehiclePurposeId,
                plateNumber,
                modelId,
                vin
            } = json;

            setPlateNr(plateNumber)
            setOutfit("")

            try {
                await fetch("/api/vehicle/purpose/id/" + vehiclePurposeId).then(res => res.json()).then(data => setPurpose(data.name))
            }
            catch (ex) {
                setPurpose("Not available")
            }
            try {
                await fetch("/api/vehicle/model/id/" + modelId).then(res => res.json()).then(async data => {
                    const Manufacturer = await fetch("/api/vehicle/manufacturer/id/" + data.manufacturerId).then(res => res.json())
                    const Version = await fetch("/api/vehicle/version/id/" + data.vehicleVersionId).then(res => res.json())

                    const Outfits = await fetch("/api/vehicle/outfitting/all" + data.vehicleVersionId).then(res => res.json())
                    /*const OutfitsArray
                    Outfits*/

                    setVehicle(String(Manufacturer.name + Version.name))
                    setOutfit(Outfit)
                })
            }
            catch (ex) {
                setVehicle("Not available")
            }
            
            setTotalMileage(totalMileage)
            
            setServiced(isInService)
        }
        handleGetData(id)
    }, [id])

    useEffect(() => {
        const handleGetData = async (id: Number | null | undefined) => {
            if (id == null || id == undefined)
                return

            const response = await fetch("/api/vehicle/vehicle/id/" + id)
            const json: JSON = await response.json()

            const {
                vehicleId,
                totalMileage,
                isInService,
                vehiclePurposeId,
                plateNumber,
                modelId,
                vin
            } = json;

            setPlateNr(plateNumber)
            setOutfit("")

            try {
                await fetch("/api/vehicle/purpose/id/" + vehiclePurposeId).then(res => res.json()).then(data => setPurpose(data.name))
            }
            catch (ex) {
                setPurpose("Not available")
            }
            try {
                await fetch("/api/vehicle/model/id/" + modelId).then(res => res.json()).then(async data => {
                    const Manufacturer = await fetch("/api/vehicle/manufacturer/id/" + data.manufacturerId).then(res => res.json())
                    const Version = await fetch("/api/vehicle/version/id/" + data.vehicleVersionId).then(res => res.json())

                    const Outfits = await fetch("/api/vehicle/outfitting/all" + data.vehicleVersionId).then(res => res.json())
                    /*const OutfitsArray
                    Outfits*/

                    setVehicle(String(Manufacturer.name + Version.name))
                    setOutfit(Outfit)
                })
            }
            catch (ex) {
                setVehicle("Not available")
            }
            
            setTotalMileage(totalMileage)
            
            setServiced(isInService)
        }
        handleGetData(id)
    }, [id])

    useEffect(() => {
        const handleGetData = async (id: Number | null | undefined) => {
            if (id == null || id == undefined)
                return

            const response = await fetch("/api/vehicle/vehicle/id/" + id)
            const json: JSON = await response.json()

            const {
                vehicleId,
                totalMileage,
                isInService,
                vehiclePurposeId,
                plateNumber,
                modelId,
                vin
            } = json;

            setPlateNr(plateNumber)
            setOutfit("")

            try {
                await fetch("/api/vehicle/purpose/id/" + vehiclePurposeId).then(res => res.json()).then(data => setPurpose(data.name))
            }
            catch (ex) {
                setPurpose("Not available")
            }
            try {
                await fetch("/api/vehicle/model/id/" + modelId).then(res => res.json()).then(async data => {
                    const Manufacturer = await fetch("/api/vehicle/manufacturer/id/" + data.manufacturerId).then(res => res.json())
                    const Version = await fetch("/api/vehicle/version/id/" + data.vehicleVersionId).then(res => res.json())

                    const Outfits = await fetch("/api/vehicle/outfitting/all" + data.vehicleVersionId).then(res => res.json())
                    /*const OutfitsArray
                    Outfits*/

                    setVehicle(String(Manufacturer.name + Version.name))
                    setOutfit(Outfit)
                })
            }
            catch (ex) {
                setVehicle("Not available")
            }
            
            setTotalMileage(totalMileage)
            
            setServiced(isInService)
        }
        handleGetData(id)
    }, [id])

    useEffect(() => {
        const handleGetData = async (id: Number | null | undefined) => {
            if (id == null || id == undefined)
                return

            const response = await fetch("/api/vehicle/vehicle/id/" + id)
            const json: JSON = await response.json()

            const {
                vehicleId,
                totalMileage,
                isInService,
                vehiclePurposeId,
                plateNumber,
                modelId,
                vin,
                caretakes,
                model,
                vehiclePurpose
            } = json;

            setPlateNr(plateNumber)
            setOutfit("")

            if (caretakes.id != null)
                await fetch("/api/employees/get/id/" + caretakes.id).then(res => res.json()).then(data => setOverseerer(data.firstName + data.surname))

            setPurpose(vehiclePurpose)
            setTotalMilage(totalMileage)
            setVehicle(model)
            setServiced(isInService)
        }
        handleGetData(id)
    }, [id])

    useEffect(() => {
        const handleGetData = async (id: Number | null | undefined) => {
            if (id == null || id == undefined)
                return

            const response = await fetch("/api/vehicle/vehicle/id/" + id)
            const json: JSON = await response.json()

            const {
                vehicleId,
                totalMileage,
                isInService,
                vehiclePurposeId,
                plateNumber,
                modelId,
                vin
            } = json;

            setPlateNr(plateNumber)
            setOutfit("")

            try {
                await fetch("/api/vehicle/purpose/id/" + vehiclePurposeId).then(res => res.json()).then(data => setPurpose(data.name))
            }
            catch (ex) {
                setPurpose("Not available")
            }
            try {
                await fetch("/api/vehicle/model/id/" + modelId).then(res => res.json()).then(async data => {
                    const Manufacturer = await fetch("/api/vehicle/manufacturer/id/" + data.manufacturerId).then(res => res.json())
                    const Version = await fetch("/api/vehicle/version/id/" + data.vehicleVersionId).then(res => res.json())

                    const Outfits = await fetch("/api/vehicle/outfitting/all" + data.vehicleVersionId).then(res => res.json())
                    /*const OutfitsArray
                    Outfits*/

                    setVehicle(String(Manufacturer.name + Version.name))
                    setOutfit(Outfit)
                })
            }
            catch (ex) {
                setVehicle("Not available")
            }
            
            setTotalMileage(totalMileage)
            
            setServiced(isInService)
        }
        handleGetData(id)
    }, [id])

    useEffect(() => {
        const handleGetData = async (id: Number | null | undefined) => {
            if (id == null || id == undefined)
                return

            const response = await fetch("/api/vehicle/vehicle/id/" + id)
            const json: JSON = await response.json()

            const {
                vehicleId,
                totalMileage,
                isInService,
                vehiclePurposeId,
                plateNumber,
                modelId,
                vin,
                caretakes,
                model,
                vehiclePurpose
            } = json;

            setPlateNr(plateNumber)
            setOutfit("")

            if (caretakes.id != null)
                await fetch("/api/employees/get/id/" + caretakes.id).then(res => res.json()).then(data => setOverseerer(data.firstName + data.surname))

            setPurpose(vehiclePurpose)
            setTotalMilage(totalMileage)
            setVehicle(model)
            setServiced(isInService)
        }
        handleGetData(id)
    }, [id])

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
                    <input type="text" style={inputStyle} value={Purpose} onChange={canModify ? (e) => setPurpose(e.target.value) : undefined}></input>
                </div>
                <div style={inputWraperStyle}>
                    Total mileage
                    <input type="text" style={inputStyle} value={TotalMileage} onChange={canModify ? (e) => setTotalMileage(e.target.value) : undefined}></input>
                </div>
            </div>
            <div style={rowStyle}>
                <div style={inputWraperStyle}>
                    Outfit
                    <input type="text" style={inputStyle} value={Outfit} onChange={canModify ? (e) => setOutfit(e.target.value) : undefined}></input>
                </div>
                <div style={inputWraperStyle}>
                    Overseerer
                    <input type="text" style={inputStyle} value={Overseerer} onChange={canModify ? (e) => setOverseerer(e.target.value) : undefined}></input>
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