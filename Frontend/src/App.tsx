import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import { Login } from './Pages/Login'
import { Register } from './Pages/Register'
import { BrowserRouter, Route, Routes } from 'react-router'
import { Planets } from './Pages/Planets'



function App() {


  return (

    <>
    <BrowserRouter>
    <Routes>
      <Route path='/' element={<Login/>} />
      <Route path='register' element={<Register/>} />
      <Route path='/planet' element={<Planets/>}/>
    </Routes>
    </BrowserRouter>
      

    </>
  )
}

export default App
