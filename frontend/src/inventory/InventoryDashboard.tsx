import {
  HorizontalScrollMenuBar,
  HorizontalScrollMenuItem,
} from "@/core/menus/horizontal-scroll-menu-bar";
import { Card, CardHeader, CardContent } from "@/core/shadcn/card";
import { useState } from "react";
import CategoryTable from "./category/CategoryTable";
import EditDialog from "@/inventory/dialogs/edit-dialog";
import { InventoryDialogProvider } from "./hooks/inventory-dialog-context";

export const links: HorizontalScrollMenuItem[] = [
  { title: "Varor", link: "rentable" },
  { title: "Delar", link: "part" },
  { title: "Gemensamt", link: "item" },
  { title: "Kategorier", link: "category" },
  { title: "Taggar", link: "tag" },
];

const InventoryDashboard = () => {
  const [selectedItem, setSelectedItem] = useState<string>(links[0].link);

  const handleMenuItemClick = (link: string) => {
    setSelectedItem(link);
  };

  const renderTable = () => {
    switch (selectedItem) {
      case "category":
        return <CategoryTable />;
      // TODO Implement other tables
      default:
        return null;
    }
  };

  return (
    <InventoryDialogProvider>
      <div className="min-h-screen overflow-auto bg-mblue-300 flex justify-center items-center">
        <Card className="bg-mneutral-100 w-11/12 min-h-[40rem] flex flex-col">
          <CardHeader>
            <div className="flex">
              <HorizontalScrollMenuBar
                links={links}
                onMenuItemClick={handleMenuItemClick}
              />
            </div>
            <CardContent className="flex-grow">{renderTable()}</CardContent>
          </CardHeader>
        </Card>
      </div>
      <EditDialog />
    </InventoryDialogProvider>
  );
};

export default InventoryDashboard;
