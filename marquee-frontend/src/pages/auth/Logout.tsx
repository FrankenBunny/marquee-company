import { useAuthentication } from '../../authcontext/AuthenticationContext';
import { Button } from '../../components/ui/button';

const Logout = () => {
    const {logout} = useAuthentication();

    const handleLogout = () => {
        // Add login logic, call to AuthenticationContext logout method
        logout();
    }


    return (
        <>
            <div>
                <Button onClick={handleLogout}>Logout</Button>
            </div>
        </>
    );
};

export default Logout;