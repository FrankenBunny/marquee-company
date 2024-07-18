import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from "../components/ui/card";
import SidebarMenu from "../components/ui/sidebar-menu";
import { LucideHome, LucideUserMinus, LucideUserPen } from "lucide-react";
import UserTable from "../components/ui/user-table";
import { ColumnDef } from "@tanstack/react-table";

type UserdashboardUser = {
  id: string;
  name: string;
  username: string;
  editurl: string;
  removeurl: string;
};

export const columns: ColumnDef<UserdashboardUser>[] = [
  {
    accessorKey: "id",
    header: "ID",
  },
  {
    accessorKey: "name",
    header: "Namn",
  },
  {
    accessorKey: "username",
    header: "Användarnamn",
  },
  {
    accessorKey: "editurl",
    header: "",
    cell: ({ row }) => (
      <a href={row.getValue("editurl")}>
        <LucideUserPen />
      </a>
    ),
  },
  {
    accessorKey: "removeurl",
    header: "",
    cell: ({ row }) => (
      <a href={row.getValue("removeurl")}>
        <LucideUserMinus />
      </a>
    ),
  },
];

export const users: UserdashboardUser[] = [
  {
    id: "1",
    name: "Alma",
    username: "AlmasInlogg",
    editurl: "test",
    removeurl: "test2",
  },
  {
    id: "2",
    name: "Emma",
    username: "EmmasInlogg",
    editurl: "test",
    removeurl: "test2",
  },
  {
    id: "3",
    name: "Carla",
    username: "CarlasInlogg",
    editurl: "test",
    removeurl: "test2",
  },
  {
    id: "4",
    name: "Julia",
    username: "JuliasInlogg",
    editurl: "test",
    removeurl: "test2",
  },
];

const UserDashboard = () => {
  return (
    <div className="min-w-screen min-h-screen bg-marquee_blue-100 flex items-center justify-center">
      <div className="bg-marquee_neutral-100 flex rounded-tr-sm rounded-br-sm">
        <div className="bg-marquee_blue-500 flex-row items-center pb-3 pt-3 justify-center rounded-tl-sm rounded-bl-sm">
          <div className="text-marquee_neutral-100 flex flex-col items-center justify-center p-5">
            <LucideHome size={30} />
            <h1 className="mb-5">Dashboard</h1>
          </div>
          <SidebarMenu />
        </div>
        <div className="">
          <Card>
            <CardHeader>
              <CardTitle>Användare</CardTitle>
              <CardDescription>Här ser du alla användare.</CardDescription>
            </CardHeader>
            <CardContent>
              <UserTable columns={columns} data={users} />
            </CardContent>
          </Card>
        </div>
      </div>
    </div>
  );
};

export default UserDashboard;
