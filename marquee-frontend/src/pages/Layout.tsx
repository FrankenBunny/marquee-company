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
        <NavigationMenu className="">
            <NavigationMenuList className="">
                <NavigationMenuItem>
                    <NavigationMenuLink className="hover:text-marquee_blue-300" asChild>
                        <a href="/" className={navigationMenuTriggerStyle()}>
                            Hem
                        </a>
                    </NavigationMenuLink>
                </NavigationMenuItem>
                <NavigationMenuItem>
                    <NavigationMenuTrigger className="hover:text-marquee_blue-300">Hantera</NavigationMenuTrigger>
                    <NavigationMenuContent className="shadow-lg">
                        <ul className="grid gap-3 p-6 text-marquee_blue-500">
                            <li className="row-span-3">
                                <NavigationMenuLink className="hover:text-marquee_blue-300" asChild>
                                    <a className="flex flex-row gap-2" href="/users">
                                        <LucideUser/>
                                        <p className="">
                                            Användare
                                        </p>
                                    </a>
                                </NavigationMenuLink>
                            </li>
                            <li className="row-span-3">
                                <NavigationMenuLink className="hover:text-marquee_blue-300" asChild>
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