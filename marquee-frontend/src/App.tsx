//import { useState } from 'react'
import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";
import Layout from "./pages/Layout";
import Home from "./pages/Home";
import UserDashboard from "./pages/UserDashboard";
import Login from "./pages/auth/Login";
import Logout from "./pages/auth/Logout";
import ProtectedRoute from "./pages/auth/ProtectedRoute";
import Error from "./pages/Error";
import { AuthenticationProvider } from "./authcontext/AuthenticationContext";
import AddUser from "./pages/admin/AddUser";
import {
  QueryClient,
  QueryClientProvider,
  useQueryClient,
} from "@tanstack/react-query";

const queryClient = new QueryClient();

function App() {
  const userType = window.localStorage.getItem("userType"); // TODO  Implement the setter in login logic

  return (
    <QueryClientProvider client={queryClient}>
      <AuthenticationProvider>
        <BrowserRouter>
          <Routes>
            <Route path="/login" element={<Login />} />
            <Route path="/" element={<Layout />}>
              <Route path="users" element={<UserDashboard />} />
              <Route path="adduser" element={<AddUser />} />
              <Route index element={<Home />} />
              {/* Protected Routes */}
              <Route element={<ProtectedRoute />}>
                <Route path="logout" element={<Logout />} />
                {userType != "Admin" ? (
                  <>
                    <Route path="users" element={<Navigate to="/" />} />
                    <Route path="adduser" element={<Navigate to="/" />} />
                  </>
                ) : (
                  <></>
                )}
              </Route>
              <Route path="error" element={<Error />} />
              <Route path="*" element={<Navigate to="/" />} />
            </Route>
          </Routes>
        </BrowserRouter>
      </AuthenticationProvider>
    </QueryClientProvider>
  );
}

export default App;
