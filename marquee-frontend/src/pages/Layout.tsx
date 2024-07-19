import { Outlet } from "react-router-dom";
import NavigationBar from "../components/ui/navbar";

const Layout = () => {
  return (
    <div className="w-screen h-screen">
      <NavigationBar />
      <Outlet />
    </div>
  );
};

export default Layout;
