import { Button } from "@/core/shadcn/button";
import { useAuthentication } from "./AuthenticationContext";

const Logout = () => {
  const { logout } = useAuthentication();

  const handleLogout = () => {
    // Add login logic, call to AuthenticationContext logout method
    logout();
  };

  return (
    <>
      <div>
        <Button onClick={handleLogout}>Logout</Button>
      </div>
    </>
  );
};

export default Logout;
