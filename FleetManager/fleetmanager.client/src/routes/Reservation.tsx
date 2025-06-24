import { useEffect, useState } from 'react';
import { Table } from '../Table';
import { DataTable } from '../DataTable';
import { table } from 'node:console';
import Vehicles from './Vehicles';


const StyleContainer: React.CSSProperties = {
    height: '89vh',
    display: 'flex',
    flexDirection: 'row'

   
}

const StylePanel: React.CSSProperties = {
    //backgroundColor: '#f0f0f0',
    border: '1px solid #ccc',
    margin: '10px',
    width: '50%',
    fontSize: 'small'
}

interface DataItem {
    [key: string]: any;
    id: number | string;
}

function Reservation() {
    const [employeeId, setEmployeeId] = useState<number | null>(2);//simulated login, should be replaced with real user data

    const [selectedVehicle, setSelectedVehicle] = useState<DataItem | null>(null); //selected vehicle for reservation
    const [vehicles, setVehicles] = useState<DataItem[]>([]);
    const [filteredVehicles, setFilteredVehicles] = useState<DataItem[]>([]);

    const [purposeMap, setPurposeMap] = useState<Map<number, string>>(new Map()); //map for vehicle purposes
    const [vehicleModelMap, setVehicleModelMap] = useState<Map<number, DataItem>>(new Map()); //map for vehicle models
    const [vehicleVersionMap, setVehicleVersionMap] = useState<Map<number, string>>(new Map()); //map for vehicle versions
    const [vehicleManufacturerMap, setVehicleManufacturerMap] = useState<Map<number, string>>(new Map()); //map for vehicle manufacturers

    const [selectedReservation, setSelectedReservation] = useState<DataItem | null>(null); //selected reservation for details
    const [reservations, setReservations] = useState<DataItem[]>([]); //list of reservations

    //const [vehicleDetailsMap, setVehicleDetailsMap] = useState<Map<number, DataItem>>(new Map()); //map for vehicle details

    //fetch data only the first time
    useEffect(() => {
        const initData = async () => {
           

            //fetch vehicle details map data
            const purposeResponse = await fetch('api/vehicle/purpose/all');
            const purposeJson: DataItem[] = await purposeResponse.json();
            const purposeMapData = new Map<number, string>(purposeJson.map(item => [item.vehiclePurposeId, item.name]));
            setPurposeMap(purposeMapData);

            const modelResponse = await fetch('api/vehicle/model/all');
            const modelJson: DataItem[] = await modelResponse.json();
            const modelMapData = new Map<number, DataItem>(modelJson.map(item => [item.modelId, item]));
            setVehicleModelMap(modelMapData);

            const versionResponse = await fetch('api/vehicle/version/all');
            const versionJson: DataItem[] = await versionResponse.json();
            const versionMapData = new Map<number, string>(versionJson.map(item => [item.versionId, item.name]));
            setVehicleVersionMap(versionMapData);

            const manufacturerResponse = await fetch('api/vehicle/manufacturer/all');
            const manufacturerJson: DataItem[] = await manufacturerResponse.json();
            const manufacturerMapData = new Map<number, string>(manufacturerJson.map(item => [item.manufacturerId, item.name]));
            setVehicleManufacturerMap(manufacturerMapData);

            

            //fetch vehicles
            const vehicleResponse = await fetch('api/vehicle/vehicle/all');
            const vehicleJson: DataItem[] = await vehicleResponse.json();
            vehicleJson.forEach(vehicle => {
                vehicle.vehiclePurposeName = purposeMapData.get(vehicle.vehiclePurposeId) || 'N/A';
                const model = modelMapData.get(vehicle.modelId);
                vehicle.manufacturerName = model ? (manufacturerMapData.get(model.manufacturerId) || 'N/A') : 'N/A';
                vehicle.versionName = model ? (versionMapData.get(model.vehicleVersionId) || 'N/A') : 'N/A';
            });
            setVehicles(vehicleJson);
            setFilteredVehicles(vehicleJson); //initialize filtered vehicles with all vehicles

            //fetch reservations
            
            const reservationResponse = await fetch(`api/reservation/get/employee/id/${employeeId}`);
            const rawData = await reservationResponse.json();
            const reservationJson: DataItem[] = Array.isArray(rawData) ? rawData : [rawData];
            //filter reservations to only include those with returned = null or returned = false
            const filteredReservations = reservationJson.filter(reservation => reservation.returned === null || reservation.returned === false);
            //for each vehicleId in reservations, fetch vehicle details
            /*
            filteredReservations.forEach(reservation => {
                //fetch vehicle details for each reservation
                fetch(`api/vehicle/vehicle/vehicle/caretake/id/${reservation.vehicleId}`)
                    .then(response => response.json())
                    .then(vehicleDetails => {
                        reservation.plate = vehicleDetails.vehicle.plateNumber;
                        const model = modelMapData.get(vehicleDetails.vehicle.modelId);
                        reservation.manufacturerName = model ? (manufacturerMapData.get(model.manufacturerId) || 'N/A') : 'N/A';
                        reservation.versionName = model ? (versionMapData.get(model.vehicleVersionId) || 'N/A') : 'N/A';
                        reservation.purposeName = purposeMapData.get(vehicleDetails.vehicle.vehiclePurposeId) || 'N/A';
                        reservation.caretakerName = vehicleDetails.caretaker.firstName + ' ' + vehicleDetails.caretaker.lastName;
                    });
                reservation.status = reservation.returned === null ? 'Pending' : (reservation.returned ? (reservation.factualBeginDate === null ? 'Rejected' : 'Returned') : (reservation.factualBeginDate === null ? 'Accepted' : 'In use'));
                //private use text
                reservation.privateUse = reservation.privateUse ? 'Yes' : 'No';
            });
            setReservations(filteredReservations);*/

            const reservationPromises = filteredReservations.map(async (reservation) => {
                try {
                    const response = await fetch(`api/vehicle/vehicle/vehicle/caretake/id/${reservation.vehicleId}`);
                    const vehicleDetails = await response.json();

                    reservation.plate = vehicleDetails.vehicle.plateNumber;
                    const model = modelMapData.get(vehicleDetails.vehicle.modelId);
                    reservation.manufacturerName = model ? (manufacturerMapData.get(model.manufacturerId) || 'N/A') : 'N/A';
                    reservation.versionName = model ? (versionMapData.get(model.vehicleVersionId) || 'N/A') : 'N/A';
                    reservation.purposeName = purposeMapData.get(vehicleDetails.vehicle.vehiclePurposeId) || 'N/A';
                    reservation.caretakerName = vehicleDetails.caretaker.firstName + ' ' + vehicleDetails.caretaker.surname;
                } catch (error) {
                    console.error(`Failed to fetch vehicle details for reservation ${reservation.reservationId}:`, error);
                    // Set default values in case of error
                    reservation.plate = 'N/A';
                    reservation.manufacturerName = 'N/A';
                    reservation.versionName = 'N/A';
                    reservation.purposeName = 'N/A';
                    reservation.caretakerName = 'N/A';
                }

                reservation.status = reservation.returned === null ? 'Pending' : (reservation.returned ? (reservation.factualBeginDate === null ? 'Rejected' : 'Returned') : (reservation.factualBeginDate === null ? 'Accepted' : 'In use'));
                reservation.privateUse = reservation.privateUse ? 'Yes' : 'No';

                return reservation;
            });

            // Wait for all promises to resolve before setting reservations
            const completedReservations = await Promise.all(reservationPromises);
            setReservations(completedReservations);

        };
        initData();
    }, []);

    const refreshReservations = async () => {
        //fetch reservations

        const reservationResponse = await fetch(`api/reservation/get/employee/id/${employeeId}`);
        const rawData = await reservationResponse.json();
        const reservationJson: DataItem[] = Array.isArray(rawData) ? rawData : [rawData];
        //filter reservations to only include those with returned = null or returned = false
        const filteredReservations = reservationJson.filter(reservation => reservation.returned === null || reservation.returned === false);
        //for each vehicleId in reservations, fetch vehicle details

        const reservationPromises = filteredReservations.map(async (reservation) => {
            try {
                const response = await fetch(`api/vehicle/vehicle/vehicle/caretake/id/${reservation.vehicleId}`);
                const vehicleDetails = await response.json();

                reservation.plate = vehicleDetails.vehicle.plateNumber;
                const model = vehicleModelMap.get(vehicleDetails.vehicle.modelId);
                reservation.manufacturerName = model ? (vehicleManufacturerMap.get(model.manufacturerId) || 'N/A') : 'N/A';
                reservation.versionName = model ? (vehicleVersionMap.get(model.vehicleVersionId) || 'N/A') : 'N/A';
                reservation.purposeName = purposeMap.get(vehicleDetails.vehicle.vehiclePurposeId) || 'N/A';
                reservation.caretakerName = vehicleDetails.caretaker.firstName + ' ' + vehicleDetails.caretaker.surname;
            } catch (error) {
                console.error(`Failed to fetch vehicle details for reservation ${reservation.reservationId}:`, error);
                // Set default values in case of error
                reservation.plate = 'N/A';
                reservation.manufacturerName = 'N/A';
                reservation.versionName = 'N/A';
                reservation.purposeName = 'N/A';
                reservation.caretakerName = 'N/A';
            }

            reservation.status = reservation.returned === null ? 'Pending' : (reservation.returned ? (reservation.factualBeginDate === null ? 'Rejected' : 'Returned') : (reservation.factualBeginDate === null ? 'Accepted' : 'In use'));
            reservation.privateUse = reservation.privateUse ? 'Yes' : 'No';

            return reservation;
        });

        // Wait for all promises to resolve before setting reservations
        const completedReservations = await Promise.all(reservationPromises);
        setReservations(completedReservations);
    }


    //filter vehicles based on selected filters
    const filterVehicles = () => {
        const brand = (document.getElementById('vehicleBrand') as HTMLSelectElement).value;
        const version = (document.getElementById('vehicleVersion') as HTMLSelectElement).value;
        const purpose = (document.getElementById('vehiclePurpose') as HTMLSelectElement).value;

        const filtered = vehicles.filter(vehicle => {
            return (brand === 'all' || vehicle.manufacturerName === brand) &&
                (version === 'all' || vehicle.versionName === version) &&
                (purpose === 'all' || vehicle.vehiclePurposeName === purpose);
        });
        setFilteredVehicles(filtered);
    };

    //function to set selected vehicle
    const setVehicle = (id: number | string) => {
        const vehicle = vehicles.find(v => v.vehicleId === id);
        setSelectedVehicle(vehicle || null);
    };

    //function to make reservation
    const makeReservation = async () => {
        if (!selectedVehicle) {
            alert('Please select a vehicle first.');
            return;
        }

        const beginDate = (document.getElementById('dateInputBegin') as HTMLInputElement).value;
        const endDate = (document.getElementById('dateInputEnd') as HTMLInputElement).value;
        const privateUse = (document.getElementById('privateUseCheckbox') as HTMLInputElement).checked;

        if (!beginDate || !endDate) {
            alert('Please select both begin and end dates.');
            return;
        }

        //fetch caretake from  api/caretake/get/vehicle/id
        const caretakerResponse = await fetch(`api/caretake/get/vehicle/id/${selectedVehicle.vehicleId}`);
        const caretakerJson: DataItem = await caretakerResponse.json();
        const caretakerId = caretakerJson.caretakeId;
        //create reservation object
        const reservation = {
            employeeId: employeeId,
            vehicleId: selectedVehicle.vehicleId,
            plannedBeginDate: beginDate,
            plannedEndDate: endDate,
            privateUse: privateUse,
            returned: null,
            factualBeginDate: null,
            factualEndDate: null,
            reservationId: 0,
            vehicleNoteBeforeReservation: '',
            vehicleNoteAfterReservation: '',
            caretakeId:  caretakerId
        };

        //send reservation request to the server
        fetch('api/reservation/create', {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(reservation)
        })
        .then(response => { 
            if (response.ok) {
                //refresh reservations
                refreshReservations();
                
            } else {
                alert('Failed to create reservation');
            }
        });
    };

    //Recent reservations(completed) panel (selectable)
    //Vehicle list panel (selectable), with filters (type, equipment, available date range)
    //My reservations panel (selectable), all pending requests[returned=null], all active[returned=false] (not returned+not started yet), last rejected[if recent?]
    return (
        <div style= {StyleContainer}>
            < div style = {{border: '1px solid #ccc', margin: '10px', fontSize: 'small', width: '60vw'}} >
                <h2>My Reservations</h2>
                <div style={{height: '19vh'}}>
                    <DataTable data={reservations} idColumn='reservationId' visibleColumns={[{ key: "plate", label: "Plate" }, { key: "manufacturerName", label: "Brand" }, { key: "versionName", label: "Version" }, { key: "purposeName", label: "Purpose" }, { key: "caretakerName", label: "Caretaker" }, { key: "plannedBeginDate", label: "Begin Date" }, { key: "plannedEndDate", label: "End Date" }, { key: "privateUse", label: "Priv. Use" }, { key: "status", label: "Status" }]}/>
                </div>
                <div style={{display: 'flex', marginLeft: '5px', marginRight: '5px'}}>
                    < div style={{width: '50%'}}>
                        <h3>Details</h3>
                    </div>
                    < div style={{width: '50%'}}>
                        <h3>Reservation</h3>
                        <div style={{display: 'flex', flexDirection: 'column', marginLeft: '5px', marginRight: '5px', alignItems: 'center'}}>
                            <p>Plate: {selectedVehicle?.plateNumber ?? "?"}</p>
                            <label style={{marginTop: '10px'}} for='dateInputBegin'>Begin date</label>
                            <input type="date" id='dateInputBegin' />
                            <label style={{marginTop: '10px'}} for='dateInputEnd'>End date</label>
                            <input type="date" id='dateInputEnd' />
                            <label style={{marginTop: '10px'}} for='privateUseCheckbox'>Private use</label>
                            <input type='checkbox' id='privateUseCheckbox' />
                            <button style={{backgroundColor: '#28a745', color: 'white', border: 'none', padding: '10px 20px', marginTop: '10px', borderRadius: '6px', cursor: 'pointer'}} onClick={makeReservation}>Make Reservation</button>
                        </div>
                    </div>
                </div>

                    

                


            </div>
            < div style = {{border: '1px solid #ccc', margin: '10px', fontSize: 'small', width: '40vw'}} >
                <h3>Filters</h3>
                <div style={{display: 'flex', justifyContent: 'center', borderBottom: '1px solid #ccc', paddingBottom: '20px'}}>
                    {/*<div style={{display: 'flex', flexDirection: 'column'}}>
                        <label for='dateInputStart'>Start date</label>
                        <input type="date" id='dateInputStart'/>  
                    </div>
                    <div style={{display: 'flex', flexDirection: 'column'}}>
                        <label for='dateInputEnd'>End date</label>
                        <input type="date" id='dateInputEnd'/>
                    </div>
                    */}
                    <div style={{display: 'flex', flexDirection: 'column', marginLeft: '5px', marginRight: '5px'}}>
                        <label for='vehicleBrand'>Brand</label>
                        <select defaultValue='all' name="vehicleBrand" id="vehicleBrand" onChange={filterVehicles}>
                            <option value="all">All</option>
                            {Array.from(vehicleManufacturerMap.entries()).map(([id, name]) => (
                                <option key={id} value={name}>{name}</option>
                            ))}
                        </select>
                    </div>
                    <div style={{display: 'flex', flexDirection: 'column', marginLeft: '5px', marginRight: '5px'}}>
                        <label for='vehicleVersion'>Version</label>
                        <select defaultValue='all' name="vehicleVersion" id="vehicleVersion" onChange={filterVehicles}>
                            <option value="all">All</option>
                            {Array.from(vehicleVersionMap.entries()).map(([id, name]) => (
                                <option key={id} value={name}>{name}</option>
                            ))}
                        </select>
                    </div>
                    <div style={{display: 'flex', flexDirection: 'column', marginLeft: '5px', marginRight: '5px'}}>
                        <label for='vehiclePurpose'>Purpose</label>
                        <select defaultValue='all' name="vehiclePurpose" id="vehiclePurpose" onChange={filterVehicles}>
                            <option value="all">All</option>
                            {Array.from(purposeMap.entries()).map(([id, name]) => (
                                <option key={id} value={name}>{name}</option>
                            ))}
                        </select>
                    </div>
                </div>
                <h2>Available Vehicles</h2>
                
                <div style={{height: '50vh'}}>
                    <DataTable data={filteredVehicles} onRowSelect={setVehicle} idColumn='vehicleId' visibleColumns={[{ key: "plateNumber", label: "Plate" }, { key: "manufacturerName", label: "Brand" }, { key: "versionName", label: "Version" }, { key: "vehiclePurposeName", label: "Purpose" }, { key: "totalMileage", label: "Mileage" }]}/>
                </div>
                
            </div>

        </div>
    );
}

export default Reservation;