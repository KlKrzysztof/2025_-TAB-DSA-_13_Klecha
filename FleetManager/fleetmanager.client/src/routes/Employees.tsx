import React, { useState } from 'react';
import './Employees.css'; // Import the CSS
import { SortableTable } from '../SortableTable';

const Employees: React.FC = () => {
    const [employeeName] = useState('Jan Paweł Nowak');
    const [selectedId, setSelectedId] = useState<number | string | null>(null);

    const handleEmplyeeSelect = (id: number | string) => {
        setSelectedId(id);
        console.log(`Employee with ID: ${id} selected`);
        // Fetch and display employee details based on the selected ID
        // You can implement the logic to fetch employee details here
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
                {/* Employees List Panel */}
                <div className="list-panel">
                    <h1 className="title">Employees List</h1>
                    <div className="employee-list" style={{maxHeight: "300px"} }>
                        <SortableTable fetchURL="weatherforecast" idColumn="id" visibleColumns={[{ key: "date", label: "Date" }, { key: "temperatureC", label: "Temperature C" }, { key: "summary", label: "Summary" }]} onRowSelect={handleEmplyeeSelect} />
                    </div>
                </div>

                {/* Employee Details Panel */}
                <div className="details-panel">
                    <input type="text" value={employeeName} readOnly className="name-heading" />

                    <div className="form-grid">
                        <input type="text" placeholder="PESEL" />
                        <input type="text" placeholder="City" />
                        <input type="text" placeholder="Tel." />
                        <input type="text" placeholder="Postal Code" />
                        <input type="text" placeholder="Tel. alt" />
                        <input type="text" placeholder="Street" />
                        <input type="text" placeholder="House no." />
                        <input type="text" placeholder="Accomodation no." />
                    </div>

                    <div className="button-group">
                        <button className="add" onClick={handleAddEmployee}>Add Employee</button>
                        <button className="delete" onClick={handleDeleteEmployee}>Delete Employee</button>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default Employees;
