import { Button } from "@/core/shadcn/button";
import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from "@/core/shadcn/card";
import { Label } from "@/core/shadcn/label";
import UserTable from "@/core/tables/user-table";
import LoadingSpinner from "@/core/ui/loading-spinner";
import { UserdashboardUser } from "@/data/user-data";
import { useQuery } from "@tanstack/react-query";
import { ColumnDef } from "@tanstack/react-table";
import { LucideUserMinus, LucideUserPen, LucideUserPlus } from "lucide-react";

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
      <div
        style={{
          display: "flex",
          justifyContent: "center",
          alignItems: "center",
        }}
      >
        <a href={row.getValue("editurl")}>
          <LucideUserPen size={18} />
        </a>
      </div>
    ),
  },
  {
    accessorKey: "removeurl",
    header: () => (
      <a href="/adduser">
        <Button className="bg-transparent hover:bg-mgreen-500 text-mgreen-500 hover:text-mneutral-100">
          <LucideUserPlus size={20} />
        </Button>
      </a>
    ),
    cell: ({ row }) => (
      <div
        style={{
          display: "flex",
          justifyContent: "center",
          alignItems: "center",
        }}
      >
        <a href={row.getValue("removeurl")}>
          <LucideUserMinus size={18} />
        </a>
      </div>
    ),
  },
];

const UserDashboard = () => {
  const { isPending, error, data } = useQuery({
    queryKey: ["usersData"],
    queryFn: async () => {
      const response = await fetch("http://localhost:8090/api/User");
      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }
      return response.json();
    },
  });

  if (isPending) {
    return (
      <div className="w-full min-h-screen overflow-auto bg-mblue-300 flex justify-center items-center">
        <div className="bg-mneutral-100 flex rounded-sm w-11/12 h-5/6 p-1">
          <Card className="w-full rounded-none border-none bg-mneutral-100 text-mneutral-900">
            <CardHeader>
              <CardTitle className="flex justify-between">
                Användare
                <LoadingSpinner size={30} />
              </CardTitle>
              <CardDescription className="flex items-center">
                Laddar in användare.
              </CardDescription>
            </CardHeader>
            <CardContent className="w-full"></CardContent>
          </Card>
        </div>
      </div>
    );
  }
  if (error) {
    if (error.message.includes("404")) {
      return (
        <div className="w-full min-h-screen overflow-auto bg-mblue-300 flex justify-center items-center">
          <div className="bg-mneutral-100 flex rounded-sm w-11/12 h-fit p-1">
            <div className="">
              <Card className="rounded-none border-none bg-mneutral-100 text-mneutral-900">
                <CardHeader>
                  <CardTitle>Användare</CardTitle>
                  <CardDescription>Här ser du alla användare.</CardDescription>
                </CardHeader>
                <CardContent className="p-1">
                  <UserTable columns={columns} data={data} />
                </CardContent>
              </Card>
            </div>
          </div>
        </div>
      );
    }
    return "An error has occurred: " + error.message;
  }
  if (!data || data.length === 0) {
    return (
      <div className="w-full min-h-screen overflow-auto bg-mblue-300 flex justify-center items-center">
        <div className="bg-mneutral-100 flex rounded-sm w-fit h-fit p-1">
          <div className="">
            <Card className="rounded-none border-none bg-mneutral-100 text-mneutral-900">
              <CardHeader>
                <CardTitle>Användare</CardTitle>
                <CardDescription>Här ser du alla användare.</CardDescription>
              </CardHeader>
              <CardContent className="p-1">
                <UserTable columns={columns} data={data} />
              </CardContent>
            </Card>
          </div>
        </div>
      </div>
    );
  }
};

export default UserDashboard;
