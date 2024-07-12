//import { useState } from 'react'
import ReactDOM from "react-dom/client";
import {BrowserRouter, Routes, Route} from 'react-router-dom'
import Layout from "./pages/Layout";
import Home from "./pages/Home";
import UserDashboard from "./pages/UserDashboard";
import { User } from 'lucide-react';


function App() {

  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Layout/>}>
          <Route index element={<Home/>}/>
          <Route path="users" element={<UserDashboard/>}/>
        </Route>
      </Routes>
    </BrowserRouter>
  )
}

const root = ReactDOM.createRoot(document.getElementById('root')!);
root.render(<App />);

export default App