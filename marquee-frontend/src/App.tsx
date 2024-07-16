//import { useState } from 'react'
import ReactDOM from "react-dom/client";
import { BrowserRouter, Routes, Route } from 'react-router-dom'
import Layout from "./pages/Layout";
import Home from "./pages/Home";
import UserDashboard from "./pages/UserDashboard";
import Login from "./pages/auth/Login";
import Logout from "./pages/auth/Logout";
import ProtectedRoute from "./pages/auth/ProtectedRoute";
import Error from "./pages/Error";
import { AuthenticationProvider } from "./authcontext/AuthenticationContext";


function App() {

  return (
    <AuthenticationProvider>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Layout/>}>
            <Route index element={<Home/>}/>

            {/* Protected Routes */}
            <Route element={<ProtectedRoute/>}>
            <Route path="users" element={<UserDashboard/>} />
            </Route>
            
            <Route path="/login" element={<Login/>} />
            <Route path="/logout" element={<Logout/>} />
            <Route path="/error" element={<Error/>} />
          </Route>
        </Routes>
      </BrowserRouter>
    </AuthenticationProvider>
  )
}

export default App;