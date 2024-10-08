//import { useState } from 'react'
import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";
import { AuthenticationProvider } from "./auth/AuthenticationContext";
import Login from "./auth/Login";
import UserDashboard from "./admin/user/UserDashboard";
import AddUser from "./admin/user/AddUser";
import InventoryDashboard from "./inventory/InventoryDashboard";
import CategoryDashboard from "./inventory/category/CategoryDashboard";
import CategoryDetails from "./inventory/category/CategoryDetails";
import ProtectedRoute from "./auth/ProtectedRoute";
import Home from "./Home";
import Logout from "./auth/Logout";
import Error from "./auth/Error";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import Layout from "./Layout";
import CategoryCreate from "./inventory/category/CategoryCreate";

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
              <Route path="inventory">
                <Route index element={<InventoryDashboard />} />
                <Route path="category">
                  <Route index element={<CategoryDashboard />} />
                  <Route path=":categoryId" element={<CategoryDetails />} />
                  <Route path="add" element={<CategoryCreate />} />
                </Route>
              </Route>
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
