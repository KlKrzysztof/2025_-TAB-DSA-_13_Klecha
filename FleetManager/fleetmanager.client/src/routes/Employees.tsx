import React, { useState } from 'react';
import './Employees.css'; // Import the CSS
import { SortableTable } from '../SortableTable';

interface Employee {
    employeeId: number;
    firstName: string;
    secondName: string;
    surname: string;
    pesel: string;
}

interface Address {
    addressId: number;
    city: string;
    street: string;
    postalCode: string;
    houseNumber: number;
    accomodationNumber: number;
    employeeId: number;
}

const Employees: React.FC = () => {
    const [selectedEmployee, setSelectedEmployee] = useState<Employee>();
    const [address, setAddress] = useState<Address>();
    const [selectedId, setSelectedId] = useState<number | string | null>(null);

    const handleEmplyeeSelect = (id: number | string) => {
        setEmployee(id);
        setEmployeeAddress(id);
    };
    async function setEmployee(id: number | string){
        setSelectedId(id);
        console.log(`Employee with ID: ${id} selected`);
        // Fetch and display employee details based on the selected ID
        // Implement the logic to fetch employee details based on the selected ID
        const response = await fetch(`api/employees/get/id/${id}`);
        const data = await response.json();
        setSelectedEmployee(data);
    };

    async function setEmployeeAddress(id: number | string) {
        const response = await fetch(`api/address/get/employee/id/${id}`);
        const data = await response.json();
        setAddress(data[0] ? data[0] : null);
    };

    const handleAddEmployee = () => {
        // Implement the logic to add a new employee
        console.log('Add Employee');
    };
    const handleDeleteEmployee = () => {
        // Implement the logic to delete the selected employee
        if (selectedId) {
            console.log(`Delete Employee with ID: ${selectedId}`);
        } else {
            console.log('No employee selected for deletion');
        }
    };

    return (
        <div className="container">
            <div className="card">
                

                {/* Employee Details Panel */}
                <div className="details-panel">
        <input type="text" value = { selectedEmployee?.firstName +" "+ selectedEmployee?.secondName +" "+ selectedEmployee?.surname } readOnly className="name-heading" />

                    <div className="form-grid">
                        <input type="text" placeholder = "PESEL" value = { selectedEmployee?.pesel} />
                        <input type="text" placeholder = "City" value = { address === null ? "" : address?.city } />
                        <input type="text" placeholder="Tel." />
                        <input type="text" placeholder = "Postal Code" value = { address === null ? "" : address?.postalCode } />
                        <input type="text" placeholder="Tel. alt" />
                        <input type="text" placeholder = "Street" value = { address === null ? "" : address?.street } />
                        < input type = "text" placeholder = "House no." value = { address === null ? "" : address?.houseNumber } />
                        < input type = "text" placeholder = "Accomodation no." value = { address === null ? "" : address?.accomodationNumber } />
                    </div>

                    <div className="button-group">
                        <button className="add" onClick={handleAddEmployee}>Add Employee</button>
                        <button className="delete" onClick={handleDeleteEmployee}>Delete Employee</button>
                    </div>
                </div>
                {/* Employees List Panel */}
                <div className="list-panel">
                    <h1 className="title">Employees List</h1>
                    <div className="employee-list" style={{maxHeight: "300px"} }>
                    <SortableTable fetchURL="api/employees/get/all" idColumn = "employeeId" onRowSelect = { handleEmplyeeSelect } visibleColumns = { [{ key: "firstName", label: "First name" }, { key: "secondName", label: "Second name" }, { key: "surname", label: "Surname" }, { key: "pesel", label: "PESEL" }]} />
                    </div>
                </div>

            </div>
        </div>
    );
};

export default Employees;
