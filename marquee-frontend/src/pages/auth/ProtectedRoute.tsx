/**
 * Protected Route
 * 
 * Todo:
 *  2 inputs, creation and utility
 * 
 * 1. Creation: declares requirements for accessing route
 * 2. Utility, redirects when requirements aren't met using AuthenticationContext
 */

import React from "react";
import { Navigate, Outlet } from "react-router-dom";
import { useAuthentication } from "../../authcontext/AuthenticationContext";

const ProtectedRoute: React.FC = () => {
  const user = useAuthentication();
  console.log("User in ProtectedRoute", user)

  return user == null ? <Outlet /> : <Navigate to="/login" />;
}

export default ProtectedRoute;


/*
import React from 'react';
import { Navigate, Outlet, redirect } from 'react-router-dom';
import { useAuthentication } from '../../authcontext/AuthenticationContext';


interface ProtectedRouteProperties {
    redirectPath?: string; 
    roles?: string[];
    claims?: string[];
    children: React.ReactElement
}
    
const ProtectedRoute: React.FC<ProtectedRouteProperties> = ({ redirectPath, roles, claims, children }) => {
    const user = useAuthentication();
    if (!user)
        console.log("Error should show")
    else
        console.log("WTH")

    // User needs to be authenticated
    return user != null ? <Outlet/> : <Navigate to={redirectPath ?? "/error"}/>

    //if (roles && !roles.includes(user.role)) {
    //    return <Redirect to='/' />;
    //}
    
    return children;
};

export default ProtectedRoute;
*/


