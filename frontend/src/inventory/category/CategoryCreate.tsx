import {
  Card,
  CardContent,
  CardFooter,
  CardHeader,
  CardTitle,
} from "@/core/shadcn/card";
import { Button } from "@/core/shadcn/button";
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
} from "@/core/shadcn/form";
import { useForm } from "react-hook-form";
import { z } from "zod";
import { zodResolver } from "@hookform/resolvers/zod";
import { Input } from "@/core/shadcn/input";

const createCategorySchema = z.object({
  title: z.string().min(4).max(30),
  description: z.string().min(4).max(200),
});

function CategoryCreate() {
  const form = useForm<z.infer<typeof createCategorySchema>>({
    resolver: zodResolver(createCategorySchema),
    defaultValues: {
      title: "Namn på kategori",
    },
  });
  //const { categoryId } = useParams<{ categoryId: string }>();
  //const { isPending, error, data } = useQuery({
  //  queryKey: ["categoryData", categoryId],
  //  queryFn: async () => {
  //    const response = await fetch(
  //      "http://localhost:8090/api/rentablecategory/" + categoryId
  //    );
  //    if (!response.ok) {
  //      throw new Error(`HTTP error! status: ${response.status}`);
  //    }
  //    return response.json();
  //  },
  //});
  function onSubmit(values: z.infer<typeof createCategorySchema>) {
    console.log(values);
  }

  return (
    <div className="min-h-screen overflow-auto bg-mblue-300 flex justify-center items-center">
      <Card className="bg-mneutral-100 w-11/12">
        <CardHeader>
          <CardTitle>Lägg till kategori</CardTitle>
          <CardContent className="">
            <div className="mt-4">
              <Form {...form}>
                <form onSubmit={form.handleSubmit(onSubmit)}>
                  <FormField
                    control={form.control}
                    name="title"
                    render={({ field }) => (
                      <FormItem>
                        <FormLabel>Namn</FormLabel>
                        <FormControl>
                          <Input {...field} />
                        </FormControl>
                      </FormItem>
                    )}
                  />
                </form>
              </Form>
            </div>
          </CardContent>
        </CardHeader>
        <CardFooter className="flex justify-center">
          <Button className="bg-mgreen-500 mr-4 w-32">
            <a href="/inventory/" className="flex">
              Skapa
            </a>
          </Button>
        </CardFooter>
      </Card>
    </div>
  );
}

export default CategoryCreate;
