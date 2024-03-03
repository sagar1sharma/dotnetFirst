import React, { Fragment, useState } from 'react'
import axios from 'axios';

function Registeration() {

    const [name, setName] = useState('');
    const [phone, setPhone] = useState('');
    const [address, setAddress] = useState('');
    const [show, setShow] = useState(false);

    const handleChangeName = (value) => {
        setName(value);
    }

    const handleChangePhone = (value) => {
        setPhone(value)
    }

    const handleChangeAddress = (value) => {
        setAddress(value)
    }

    const handleSave = () => {
        const data = {
            Name: name,
            PhoneNo: phone,
            Address: address,
            IsActive: 1
        };
        
        const url = 'http://localhost:55870/api/Test/Registeration';
        axios.post(url,data).then((result) => {
            alert(result.data);
        }).catch((error) => {
            alert(error);
        })
    }

    function toggleShow(){
        setShow(!show);
    }

  return (
    <div>
        <button className='btn' onClick={() => toggleShow()}>Registeration</button><br></br>
        {show && (
        <>
        <label>Name </label>
        <input type='text' placeholder='Enter Name' id='txtName' onChange={(e) => handleChangeName(e.target.value)}></input><br></br>
        <label>Phone No </label>
        <input type='text' placeholder='Enter Phone Number' id='PhoneNo' onChange={(e) => handleChangePhone(e.target.value)}></input><br></br>
        <label>Address  </label>
        <input type='text' placeholder='Enter Address' id='address' onChange={(e) => handleChangeAddress(e.target.value)}></input><br></br>
        <button onClick={() => handleSave()}>Save</button>
        </>
        )}
        
    </div>
  )
}

export default Registeration