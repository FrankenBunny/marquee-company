import { useParams } from "react-router-dom";
import { useQuery } from "@tanstack/react-query";
import { LucidePen, LucideTrash } from "lucide-react";
import {
  Card,
  CardHeader,
  CardContent,
  CardFooter,
  CardTitle,
} from "@/core/shadcn/card";
import { Label } from "@/core/shadcn/label";
import { Button } from "@/core/shadcn/button";

function CategoryDetails() {
  const { categoryId } = useParams<{ categoryId: string }>();
  const { isPending, error, data } = useQuery({
    queryKey: ["categoryData", categoryId],
    queryFn: async () => {
      const response = await fetch(
        "http://localhost:8080/api/rentablecategory/" + categoryId
      );
      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }
      return response.json();
    },
  });

  if (isPending) {
    return (
      <div className="min-h-screen overflow-auto mx-2 bg-marquee_blue-300 flex justify-center items-center">
        <Card className="bg-marquee_neutral-100 w-full">
          <CardHeader>
            <CardTitle>Kategori</CardTitle>
            <CardContent>
              <Label>Laddar in kategori information</Label>
            </CardContent>
          </CardHeader>
        </Card>
      </div>
    );
  }
  if (error) {
    if (error.message.includes("404")) {
      return (
        <div className="min-h-screen overflow-auto mx-2 bg-marquee_blue-300 flex justify-center items-center">
          <Card className="bg-marquee_neutral-100 w-full">
            <CardHeader>
              <CardTitle>Kategori</CardTitle>
              <CardContent>
                <Label>Lyckades inte ladda kategorin.</Label>
              </CardContent>
            </CardHeader>
          </Card>
        </div>
      );
    }
    return "An error has occurred: " + error.message;
  }

  return (
    <div className="min-h-screen overflow-auto mx-2 bg-marquee_blue-300 flex justify-center items-center">
      <Card className="bg-marquee_neutral-100 w-full">
        <CardHeader>
          <CardTitle>
            <div className="flex items-baseline w-full justify-between">
              <p className="text-sm italic font-normal">Kategori</p>
              <Button className="bg-marquee_red-500 ml-16">
                <a href="/remove">
                  <LucideTrash />
                </a>
              </Button>
            </div>
            {data.title}
          </CardTitle>
          <CardContent className="m-0 p-0">
            <div className="">
              <p>{data.description}</p>
            </div>
          </CardContent>
        </CardHeader>
        <CardFooter className="flex justify-center">
          <Button className="bg-marquee_blue-500 mr-4 w-32">
            <a href="/edit" className="flex">
              Redigera
              <LucidePen className="ml-4" />
            </a>
          </Button>
        </CardFooter>
      </Card>
    </div>
  );
}

export default CategoryDetails;
