import { useState } from "react";
import {
  HorizontalScrollMenuBar,
  HorizontalScrollMenuItem,
} from "@/components/menu-bars/horizontal-scroll-menu-bar";
import { Card, CardContent, CardHeader } from "@/components/ui/card";
import CategoryTable from "@/components/ui/tables/CategoryTable";

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
    <div className="min-h-screen overflow-auto mx-2 bg-marquee_blue-300 flex justify-center items-center">
      <Card className="bg-marquee_neutral-100 w-full">
        <CardHeader>
          <div className="flex">
            <HorizontalScrollMenuBar
              links={links}
              onMenuItemClick={handleMenuItemClick}
            />
          </div>
          <CardContent>{renderTable()}</CardContent>
        </CardHeader>
      </Card>
    </div>
  );
};

export default InventoryDashboard;
