import {
  Card,
  CardContent,
  CardFooter,
  CardHeader,
  CardTitle,
} from "@/core/shadcn/card";
import { useMutation, useQuery } from "@tanstack/react-query";
import { Label } from "@radix-ui/react-label";
import { LucideSave } from "lucide-react";
import { Button } from "@/core/shadcn/button";
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
} from "@/core/shadcn/form";
import { Input } from "@/core/shadcn/input";
import { z } from "zod";
import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";
import { useEffect } from "react";
import LoadingSpinner from "@/core/ui/loading-spinner";

const uuidPattern =
  /^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}$/;

const editCategorySchema = z.object({
  id: z.string().regex(uuidPattern, "Invalid UUID format"),
  title: z
    .string()
    .min(4, { message: "Namn får inte bestå av färre än 4 karaktärer." })
    .max(30, { message: "Namn får inte överstiga 30 karaktärer." }),
  description: z
    .string()
    .min(4, { message: "Beskrivning får inte bestå av färre än 4 karaktärer." })
    .max(200, { message: "Beskrivning får inte överstiga 200 karaktärer." }),
});

interface CategoryEditProps {
  categoryId: string;
}

const CategoryEdit = ({ categoryId }: CategoryEditProps) => {
  const { isPending, error, data } = useQuery({
    queryKey: ["categoryData", categoryId],
    queryFn: async () => {
      const response = await fetch(
        "http://localhost:8090/api/rentablecategory/" + categoryId
      );
      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }
      return response.json();
    },
  });

  const mutation = useMutation({
    mutationFn: async (values: z.infer<typeof editCategorySchema>) => {
      const response = await fetch(
        "http://localhost:8090/api/rentablecategory/" + categoryId,
        {
          method: "PUT",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(values),
        }
      );
      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }
      return null;
    },
    onError: (error: Error) => {
      console.error("Error updating category:", error.message);
    },
  });

  function onSubmit(values: z.infer<typeof editCategorySchema>) {
    console.log(values);
    mutation.mutate(values);
  }

  const form = useForm<z.infer<typeof editCategorySchema>>({
    resolver: zodResolver(editCategorySchema),
    defaultValues: {
      id: "",
      title: "Lyckades inte hämta namn",
      description: "Lyckades inte hämta beskrivning",
    },
  });

  useEffect(() => {
    if (data) {
      form.reset({
        id: categoryId,
        title: data.title || "Lyckades inte hämta namn",
        description: data.description || "Lyckades inte hämta beskrivning",
      });
    }
  }, [data, form]);

  if (isPending) {
    return (
      <div className="overflow-auto mx-2 bg-mblue-300 flex justify-center items-center">
        <Card className="bg-mneutral-100 w-full">
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
        <div className="overflow-auto mx-2 bg-mblue-300 flex justify-center items-center">
          <Card className="bg-mneutral-100 w-full">
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
    <div className="overflow-auto flex justify-center items-center shadow-none outline-none border-none">
      <Card className="bg-mneutral-100 px-4 w-full shadow-none outline-none border-none">
        <CardHeader className="px-0">
          <CardTitle>
            <div className="flex w-full justify-start">
              <h1 className="text-left">Redigera Kategori</h1>
            </div>
          </CardTitle>
        </CardHeader>
        <CardContent className="m-0 p-0">
          <Form {...form}>
            <form onSubmit={form.handleSubmit(onSubmit)}>
              <input type="hidden" key="id" value={categoryId} />
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
              <FormField
                control={form.control}
                name="description"
                render={({ field }) => (
                  <FormItem className="mt-4">
                    <FormLabel>Beskrivning</FormLabel>
                    <FormControl>
                      <Input {...field} />
                    </FormControl>
                  </FormItem>
                )}
              />
              {form.formState.errors.title && (
                <p className="text-mred-500">
                  {form.formState.errors.title.message as string}
                </p>
              )}
              {form.formState.errors.description && (
                <p className="text-mred-500">
                  {form.formState.errors.description.message as string}
                </p>
              )}
              <div className="flex justify-center mt-4 mb-1">
                <Button
                  className="bg-mgreen-500 hover:bg-mgreen-300 active:bg-mgreen-700 focus:bg-mgreen-500"
                  type="submit"
                >
                  <LucideSave className="" />
                </Button>
              </div>
            </form>
          </Form>
        </CardContent>
        <CardFooter className="flex justify-center mt-0">
          {mutation.isPending && <LoadingSpinner size={20} />}
          {mutation.isSuccess && (
            <div className="flex justify-center text-mgreen-500">
              <span>Lyckades!</span>
            </div>
          )}
          {mutation.isError && (
            <div className="flex justify-center text-mred-500">
              <span>Något gick fel!</span>
            </div>
          )}
        </CardFooter>
      </Card>
    </div>
  );
};

export default CategoryEdit;
