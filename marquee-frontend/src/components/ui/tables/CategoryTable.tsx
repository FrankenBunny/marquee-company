import { useQuery } from "@tanstack/react-query";
import { Label } from "@radix-ui/react-label";
import { Category } from "@/assets/data/category";
import { CategoryTableComponent } from "./category-table-component";
import { ColumnDef } from "@tanstack/react-table";

export const columns: ColumnDef<Category>[] = [
  {
    accessorKey: "title",
    header: "Namn",
    cell: ({ row }) => (
      <div className="overflow-auto whitespace-nowrap max-w-[110px]">
        <Label className="whitespace-nowrap">{row.getValue("title")}</Label>
      </div>
    ),
  },
];

function CategoryTable() {
  const { isPending, error, data } = useQuery({
    queryKey: ["categoryData"],
    queryFn: async () => {
      const response = await fetch(
        "http://localhost:8090/api/RentableCategory"
      );
      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }
      console.log("Response json "+ response.json());
      
      return response.json();
    },
  });

  if (isPending) {
    return <Label>Laddar in kategorier.</Label>;
  }
  if (error) {
    if (error.message.includes("404")) {
      return <CategoryTableComponent columns={columns} data={data} />;
    }
    return "An error has occurred: " + error.message;
  }
  return <CategoryTableComponent columns={columns} data={data} />;
}

export default CategoryTable;
