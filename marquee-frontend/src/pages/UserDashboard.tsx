import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from "../components/ui/card";
import { LucideUserMinus, LucideUserPen } from "lucide-react";
import UserTable from "../components/ui/user-table";
import { ColumnDef } from "@tanstack/react-table";
import UserData, { UserdashboardUser } from "../assets/data/user-data";
import { Label } from "@radix-ui/react-label";

export const columns: ColumnDef<UserdashboardUser>[] = [
  {
    accessorKey: "name",
    header: "Namn",
  },
  {
    accessorKey: "username",
    header: "Användarnamn",
    cell: ({ row }) => (
      <div className="overflow-auto whitespace-nowrap max-w-[110px]">
        <Label className="whitespace-nowrap">{row.getValue("username")}</Label>
      </div>
    ),
  },
  {
    accessorKey: "editurl",
    header: "",
    cell: ({ row }) => (
      <a href={row.getValue("editurl")}>
        <LucideUserPen size={18} />
      </a>
    ),
  },
  {
    accessorKey: "removeurl",
    header: "",
    cell: ({ row }) => (
      <a href={row.getValue("removeurl")}>
        <LucideUserMinus size={18} />
      </a>
    ),
  },
];

const UserDashboard = () => {
  return (
    <div className="w-full min-h-screen overflow-auto bg-marquee_blue-300 flex justify-center items-center">
      <div className="bg-marquee_neutral-100 flex rounded-sm w-fit h-fit p-1">
        <div className="">
          <Card className="rounded-none border-none bg-marquee_neutral-100 text-marquee_neutral-900">
            <CardHeader>
              <CardTitle>Användare</CardTitle>
              <CardDescription>Här ser du alla användare.</CardDescription>
            </CardHeader>
            <CardContent className="p-1">
              <UserTable columns={columns} data={UserData} />
            </CardContent>
          </Card>
        </div>
      </div>
    </div>
  );
};

export default UserDashboard;

/*
<div className="w-full min-h-screen bg-marquee_blue-300 flex items-center justify-center">
<div className="bg-marquee_neutral-100 flex rounded-sm">
  <div className="bg-marquee_neutral-100 items-center pb-3 pt-3 justify-center rounded-tl-sm rounded-bl-s">
    <div className="text-marquee_neutral-100 flex flex-col items-center justify-center p-5">
      <LucideHome size={30} color="#000F1F" />
      <h1 className="mb-5 text-marquee_neutral-900">Dashboard</h1>
    </div>
    <SidebarMenu />
  </div>
  <div className="">
    <Card className="rounded-none border-none">
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
*/
