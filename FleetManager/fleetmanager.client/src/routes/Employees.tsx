import React, { useState } from 'react';
import './Employees.css'; // Import the CSS
import { Table } from '../Table';
import { Addresses } from '../Addresses';
import { ContactInfo } from '../ContactInfo';

const StyleContainer: React.CSSProperties = {
    display: 'flex',
    justifyContent: 'center',
    alignItems: 'center',
    backgroundColor: '#f2f2f2',
    height: '89vh'
}

const StyleCard: React.CSSProperties = {
    display: 'flex',
    alignItems: 'baseline',
    flexDirection: 'row-reverse',
    backgroundColor: 'white',
    borderRadius: '12px',
    padding: '20px',
    width: '90%',
    maxWidth: '1100px',
    boxShadow: '0 0 10px rgba(0, 0, 0, 0.1)'
}

const StyleListPanel: React.CSSProperties = {
    flex: '2',
    marginRight: '20px',
    display: 'flex',
    flexDirection: 'column',
    minWidth: 'auto',
    
}

const StyleTitle: React.CSSProperties = {
    textAlign: 'center',
    fontSize: '28px',
    marginBottom: '10px'
}

const StyleDetailsTop: React.CSSProperties = {
    display: 'flex',
    justifyContent: 'space-between'
}

const StyleEmployeeList: React.CSSProperties = {
    flexGrow: '1',
    backgroundColor: 'white',
    borderRadius: '6px',
    height: '40vh'
}

const StyleDetailsPanel: React.CSSProperties = {
    flex: '1',
    display: 'flex',
    flexDirection: 'column',
    borderLeft: '1px solid #ccc',
    paddingLeft: '20px',
}

const StyleNameHeading: React.CSSProperties = {
    width: '80%',
    textAlign: 'center',
    fontSize: '24px',
    fontWeight: 'bold',
    padding: '10px',
    border: '1px solid #ccc',
    borderRadius: '6px',
    marginBottom: '20px'
}

const StyleDetailsMiddle: React.CSSProperties = {
    display: 'flex',
    justifyContent: 'space-between'
}

const StyleDetailsColumn: React.CSSProperties = {
    margin: '5px'
}


const StyleAddressItem: React.CSSProperties = {
    display: 'flex',
    marginBottom: '5px'
}

const StyleAddressText: React.CSSProperties = {
    margin: "0",
    textWrapStyle: "balance"
}

const StyleInputLabel: React.CSSProperties = {
    margin: "0"
}

const StyleFormGridInput: React.CSSProperties = {
    padding: '10px',
    borderRadius: '6px',
    border: '1px solid #ccc',
    marginBottom: '5px'
}

const StyleButtonGroup: React.CSSProperties = {
    marginTop: '20px',
    display: 'flex',
    gap: '10px'
}

const StyleAdd: React.CSSProperties = {
    backgroundColor: '#28a745',
    color: 'white',
    border: 'none',
    padding: '10px 20px',
    borderRadius: '6px',
    cursor: 'pointer'
}

const StyleUpdate: React.CSSProperties = {
    backgroundColor: '#3ba6ff',
    color: 'white',
    border: 'none',
    padding: '10px 20px',
    borderRadius: '6px',
    cursor: 'pointer'
}

const StyleDelete: React.CSSProperties = {
    backgroundColor: '#c0392b',
    color: 'white',
    border: 'none',
    padding: '10px 20px',
    borderRadius: '6px',
    cursor: 'pointer'
}

const StyleConfig: React.CSSProperties = {
    backgroundColor: '#c0c0c0',
    color: 'black',
    border: 'none',
    padding: '10px 20px',
    borderRadius: '6px',
    cursor: 'pointer'
}

const StyleRemove: React.CSSProperties = {
    backgroundColor: '#c0392b',
    color: 'white',
    border: 'none',
    //padding: '10px 20px',
    borderRadius: '6px',
    cursor: 'pointer'
}

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
    accommodationNumber: number;
    employeeId: number;
}

interface ContactInfo {
    contactId: number;
    employeeId: number;
    telNumber: string;
}

export const Employees: React.FC = () => {
    const [selectedEmployee, setSelectedEmployee] = useState<Employee>();
    const [addresses, setAddresses] = useState<Address[]>([]);
    const [contact, setContact] = useState<ContactInfo>();
    const [altContact, setAltContact] = useState<ContactInfo>();
    const [selectedId, setSelectedId] = useState<number | string | null>(null);

    const [isModalOpen, setIsModalOpen] = useState(false);

    const [forceRefresh, setForceRefresh] = useState<number>(0);

    const openModal = () => {
        setIsModalOpen(true);
    }
    const closeModal = () => {
        setIsModalOpen(false);
        setEmployeeAddresses(selectedId); // Refresh addresses when modal is closed
    }

    const handleEmployeeSelect = (id: number | string) => {
        setEmployee(id);
        setEmployeeAddresses(id);
        setEmployeeContacts(id);
    };
    async function setEmployee(id: number | string){
        setSelectedId(id);
        console.log(`Employee with ID: ${id} selected`);
        // Fetch and display employee details based on the selected ID
        // Implement the logic to fetch employee details based on the selected ID
        const response = await fetch(`api/employee/get/id/${id}`);
        const data = await response.json();
        setSelectedEmployee(data);
    };

    function setEmployeeNames(nameString: string) {
        //parse the name string into firstName, secondName, and surname
        const names = nameString.split(' ');
        const firstName = names[0] || '';
        const secondName = names.length > 2 ? names[1] : '';
        const surname = names.length > 2 ? names[2] : (names[1] || '');
        setSelectedEmployee({
            ...selectedEmployee,
            firstName: firstName,
            secondName: secondName,
            surname: surname
        });
    };

    async function setEmployeeAddresses(id: number | string) {
        //check if id is null or undefined
        if (id === null || id === undefined) {
            //setAddresses([]);
            return;
        }
        const response = await fetch(`api/address/get/employee/id/${id}`);
        const data = await response.json();
        setAddresses(data);
    };

    async function unlinkAddress(index: number) {

        let adr = addresses[index];
        adr.employeeId = null; // Unlink the address by setting employeeId to null
        console.log(`Unlink Address with ID: ${adr.addressId}`);
        fetch(`api/address/update`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(adr)
        })
        .then(response => {
            if (response.ok) {
                console.log('Address unlinked successfully');
                setEmployeeAddresses(selectedId);
            } else {
                console.error('Error updating address');
            }
        });
        
    };

    async function setEmployeeContacts(id: number | string) {
        const response = await fetch(`api/contact/get/employee/id/${id}`);
        const data = await response.json();
        setContact(data[0] ? data[0] : null);
        setAltContact(data[1] ? data[1] : null);
    };

    const handleAddEmployee = () => {
        // Implement the logic to add a new employee
        console.log('Add Employee');
        const newEmployee: Employee = {
            employeeId: 0,
            firstName: "firstName",
            secondName: "secondName",
            surname: "surname",
            pesel: "00000000000"
        };
        fetch(`api/employee/create/contact/123456789/123456789`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(newEmployee)
        })
        .then(response => {
            if (response.ok) {
                console.log('Employee added successfully');
                // Refresh the employee list
                setForceRefresh(forceRefresh + 1);
            } else {
                console.error('Error adding employee');
            }
        });
    };

    const handleUpdateEmployee = () => {
        // Implement the logic to update the selected employee
        if (selectedEmployee) {
            console.log(`Update Employee with ID: ${selectedEmployee.employeeId}`);
            fetch(`api/employee/update`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(selectedEmployee)
            })
            .then(response => {
                if (response.ok) {
                    console.log('Employee updated successfully');
                    setForceRefresh(forceRefresh + 1);
                    //update contacts
                    fetch(`api/contact/update`, {
                        method: 'POST',
                        headers: {
                            'Content-Type': 'application/json',
                        },
                        body: JSON.stringify(contact)
                    })
                    .then(response => {
                        if (response.ok) {
                            console.log('Contact updated successfully');
                        } else {
                            console.error('Error updating contact');
                        }
                    });
                    fetch(`api/contact/update`, {
                        method: 'POST',
                        headers: {
                            'Content-Type': 'application/json',
                        },
                        body: JSON.stringify(altContact)
                    })
                    .then(response => {
                        if (response.ok) {
                            console.log('Alt Contact updated successfully');
                        } else {
                            console.error('Error updating alt contact');
                        }
                    });
                    
                } else {
                    console.error('Error updating employee');
                }
            });
        } else {
            console.log('No employee selected for update');
        }
    };

    const handleDeleteEmployee = () => {
        // Implement the logic to delete the selected employee
        if (selectedEmployee) {
            console.log(`Delete Employee with ID: ${selectedEmployee.employeeId}`);
            fetch(`api/employee/delete/${selectedEmployee.employeeId}`, {
                method: 'DELETE',
            })
            .then(response => {
                if (response.ok) {
                    console.log('Employee deleted successfully');
                    setSelectedEmployee(undefined);
                    setAddresses([]);
                    setContact(undefined);
                    setAltContact(undefined);
                    setSelectedId(null);
                    setForceRefresh(forceRefresh + 1); // Refresh the employee list
                } else {
                    console.error('Error deleting employee');
                }
            });
        } else {
            console.log('No employee selected for deletion');
        }
    };

    return (
        <div style = {StyleContainer}>
            <div style = {StyleCard}>
                {/* Employee Details Panel */}
                < div  style = { StyleDetailsPanel } >
                    <h1  style={StyleTitle}>Employee Details</h1>
                    <div  style = { StyleDetailsTop} >
                        <p style={{minWidth: "fit-content"}}> { selectedEmployee?.employeeId ? `ID: ${selectedEmployee.employeeId}` : "ID: ?"} </p>
                        < input style = { StyleNameHeading } type = "text" placeholder = "Full Name" value = { (selectedEmployee?.firstName ?? "") + (selectedEmployee?.secondName ? " " + selectedEmployee?.secondName + " " : (selectedEmployee ? " " : "")) + (selectedEmployee?.surname ?? "") } onChange = {e => setEmployeeNames(e.target.value) }/>
                    </div>

                    <div style={StyleDetailsMiddle}>
                        <div style={StyleDetailsColumn}>
                            <p style={StyleInputLabel}>PESEL</p>
                            < input size="12" style = { StyleFormGridInput } type = "text" placeholder = "PESEL" value = { selectedEmployee?.pesel ?? ""} onChange = { e => setSelectedEmployee({ ...selectedEmployee, pesel: e.target.value }) }/>
                            < p style={StyleInputLabel}> Tel. </p>
                            < input size="12" style = { StyleFormGridInput } type = "tel" placeholder = "Tel." value = { contact?.telNumber ?? ""} onChange = { e => setContact({ ...contact, telNumber: e.target.value }) }/>
                            < p style={StyleInputLabel}> Tel. alt </p>
                            < input size="12" style = { StyleFormGridInput } type = "tel" placeholder = "Tel. alt" value = { altContact?.telNumber ?? ""} onChange = { e => setAltContact({ ...altContact, telNumber: e.target.value }) }/>
                        </div>

                        < div style = { StyleDetailsColumn } >
                            {addresses.map((address, index) => (
                                
                                <div key={index} style={StyleAddressItem}>
                                    <p style={StyleAddressText}>{`${address.street} ${address.houseNumber}${address.accommodationNumber ? `/${address.accommodationNumber}` : ""}, ${address.postalCode} ${address.city}`}</p>
                                    <button style={StyleRemove} onClick={() => unlinkAddress(index)}>X</button>
                                </div>
                            ))}

                            < button style={StyleConfig} onClick = { openModal } > Manage Addresses </button>
                            {isModalOpen && (
                                <div style={ modalBackdropStyle }>
                                <Addresses linkEmployeeId={ selectedId } onClose={ closeModal }/>
                                </div>
                                )}
                        </div>
                    </div>

                    <div style={StyleButtonGroup}>
                        <button style={StyleAdd} onClick={handleAddEmployee}>Add</button>
                        <button style={StyleUpdate} onClick={handleUpdateEmployee}>Update</button>
                        <button style={StyleDelete} onClick={handleDeleteEmployee}>Delete</button>
                    </div>
                </div>

                {/* Employees List Panel */}
                <div style={StyleListPanel}>
                    <h1 style={StyleTitle}>Employees List</h1>
                    <div style={StyleEmployeeList}>
                        <Table fetchURL="api/employee/get/all" idColumn = "employeeId" onRowSelect = { handleEmployeeSelect } refreshOnChange = { forceRefresh } visibleColumns = { [{ key: "employeeId", label: "ID" }, { key: "firstName", label: "First name" }, { key: "secondName", label: "Second name" }, { key: "surname", label: "Surname" }, { key: "pesel", label: "PESEL" }]} />
                    </div>
                </div>
            </div>
        </div>
    );
};

// Simple backdrop style
const modalBackdropStyle: React.CSSProperties = {
    position: 'fixed',
    top: 0,
    left: 0,
    right: 0,
    bottom: 0,
    backgroundColor: 'rgba(0,0,0,0.5)',
    display: 'flex',
    justifyContent: 'center',
    alignItems: 'center',
    zIndex: '1'
};

export default Employees;
