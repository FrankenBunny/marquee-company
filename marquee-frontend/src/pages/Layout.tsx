import { Outlet, Link } from "react-router-dom";
import {
    NavigationMenu,
    NavigationMenuContent,
    NavigationMenuIndicator,
    NavigationMenuItem,
    NavigationMenuLink,
    NavigationMenuList,
    NavigationMenuTrigger,
    NavigationMenuViewport,
} from "@/components/ui/navigation-menu"
import { navigationMenuTriggerStyle } from "../components/ui/navigation-menu";
import { LucideLock, LucideUser } from "lucide-react";


const Layout = () => {
  return (
    <>
        <NavigationMenu className="shadow-lg max-w-full justify-start">
            <NavigationMenuList className="">
                <NavigationMenuItem>
                    <NavigationMenuLink asChild>
                        <a href="/" className={navigationMenuTriggerStyle()}>
                            Hem
                        </a>
                    </NavigationMenuLink>
                </NavigationMenuItem>
                <NavigationMenuItem>
                    <NavigationMenuTrigger>Hantera</NavigationMenuTrigger>
                    <NavigationMenuContent className="shadow-lg">
                        <ul className="grid gap-3 p-6">
                            <li className="row-span-3">
                                <NavigationMenuLink asChild>
                                    <a className="flex flex-row gap-2" href="/users">
                                        <LucideUser/>
                                        <p className="">
                                            Användare
                                        </p>
                                    </a>
                                </NavigationMenuLink>
                            </li>
                            <li className="row-span-3">
                                <NavigationMenuLink asChild>
                                    <a className="flex flex-row gap-2" href="/users">
                                        <LucideLock/>
                                        <p className="">
                                            Roller
                                        </p>
                                    </a>
                                </NavigationMenuLink>
                            </li>
                        </ul>
                    </NavigationMenuContent>
                </NavigationMenuItem>
            </NavigationMenuList>
        </NavigationMenu>
      <Outlet />
    </>
  )
};

export default Layout;