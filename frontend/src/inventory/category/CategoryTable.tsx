import { Button } from "@/core/shadcn/button";
import { Label } from "@/core/shadcn/label";
import { CategoryTableComponent } from "@/core/tables/category-table-component";
import LoadingSpinner from "@/core/ui/loading-spinner";
import { Category } from "@/data/category";
import { useQuery } from "@tanstack/react-query";
import { ColumnDef } from "@tanstack/react-table";
import { LucidePen, LucidePlus, LucideTrash2 } from "lucide-react";
import { useInventoryDialog } from "../hooks/inventory-dialog-context";

function CategoryTable() {
  const { openDialog } = useInventoryDialog();

  const columns: ColumnDef<Category>[] = [
    {
      accessorKey: "title",
      header: "Namn",
      cell: ({ row }) => (
        <div className="overflow-auto whitespace-nowrap max-w-[110px]">
          <Label className="whitespace-nowrap">{row.getValue("title")}</Label>
        </div>
      ),
    },
    {
      accessorKey: "edit",
      header: "",
      cell: ({ row }) => (
        <div className="flex justify-end">
          <Button
            variant="ghost"
            size="icon"
            className="text-mblue-500"
            onClick={() => openDialog("category", row.original.id)}
          >
            <LucidePen className="w-5 h-5" />
          </Button>
        </div>
      ),
    },
    {
      accessorKey: "remove",
      header: () => (
        <div className="flex text-mgreen-500 justify-end">
          <a href="inventory/category/add">
            <LucidePlus className="w-6 h-6" />
          </a>
        </div>
      ),
      cell: () => (
        <a
          href="inventory/category/add"
          className="flex text-mred-500 justify-end "
        >
          <LucideTrash2 className="w-6 h-6" />
        </a>
      ),
    },
  ];

  const { isPending, error, data } = useQuery({
    queryKey: ["categoryData"],
    queryFn: async () => {
      const response = await fetch(
        "http://localhost:8090/api/RentableCategory"
      );
      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }

      return response.json();
    },
  });

  if (isPending) {
    return (
      <div className="flex flex-col items-center">
        <LoadingSpinner size={30} />
        <Label>Laddar in kategorier.</Label>
      </div>
    );
  }
  if (error) {
    if (error.message.includes("404")) {
      return <CategoryTableComponent columns={columns} data={data} />;
    }
  }
  return <CategoryTableComponent columns={columns} data={data} />;
}

export default CategoryTable;
