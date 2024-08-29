import NavigationBar from "@/components/ui/navbar";
import { Outlet } from "react-router-dom";


const Layout = () => {
  return (
    <div className="w-screen h-screen">
      <NavigationBar />
      <Outlet />
    </div>
  );
};

export default Layout;
