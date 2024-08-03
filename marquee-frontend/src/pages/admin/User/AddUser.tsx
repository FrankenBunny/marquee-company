import { Card, CardHeader, CardTitle, CardContent } from "@/components/ui/card";
import { z } from "zod";
import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";
import { Button } from "@/components/ui/button";
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form";
import { Input } from "@/components/ui/input";
import { useMutation } from "@tanstack/react-query";
import { useNavigate } from "react-router-dom";
import { useEffect } from "react";

const addUserSchema = z.object({
  name: z
    .string()
    .min(4, {
      message: "Name must be at least 4 characters.",
    })
    .max(50, {
      message: "Name cannot contain more than 50 characters.",
    })
    .regex(/^[a-zA-Z åÅäÄöÖ]{2,50}$/i, {
      message: "Name may only contain lower- and uppercase letters.",
    }),
  username: z
    .string()
    .min(4, {
      message: "Username must be at least 4 characters.",
    })
    .max(50, {
      message: "Username cannot contain more than 50 characters.",
    })
    .regex(/^[a-z0-9]{4,20}$/i, {
      message: "Username may contain lowercase letters and numbers 0-9.",
    }),
  email: z
    .string()
    .regex(/^((?!\.)[\w\-_.]*[^.])(@\w+)(\.\w+(\.\w+)?[^.\W])$/i, {
      message: "email must be in format abc@abc.com",
    }),
  passwordHash: z.string().min(8).max(256),
});

type UserFormValues = z.infer<typeof addUserSchema>;

const AddUser = () => {
  const navigate = useNavigate();

  const form = useForm<z.infer<typeof addUserSchema>>({
    resolver: zodResolver(addUserSchema),
    defaultValues: {
      name: "",
      username: "",
      passwordHash: "",
      email: "",
    },
  });

  const mutation = useMutation({
    mutationFn: (newUser: UserFormValues) => {
      return fetch("http://localhost:5019/User", {
        method: "POST",
        body: JSON.stringify(newUser),
        headers: {
          "Content-Type": "application/json",
        },
      });
    },
  });

  useEffect(() => {
    if (mutation.isSuccess) {
      navigate("/users");
    } else if (mutation.isError) {
      navigate("/error");
    }
  }, [mutation]);

  const onSubmit = (values: z.infer<typeof addUserSchema>) => {
    mutation.mutate(values);
  };

  return (
    <div className="flex justify-center">
      <div className="mt-10 w-11/12">
        <Card>
          <CardHeader>
            <CardTitle>Skapa en ny användare.</CardTitle>
          </CardHeader>
          <CardContent>
            <Form {...form}>
              <form
                onSubmit={form.handleSubmit(onSubmit)}
                className="space-y-8"
              >
                <FormField
                  control={form.control}
                  name="name"
                  render={({ field }) => (
                    <FormItem>
                      <FormLabel>Namn</FormLabel>
                      <FormControl>
                        <Input placeholder="Namn" {...field} />
                      </FormControl>
                      <FormMessage />
                    </FormItem>
                  )}
                />
                <FormField
                  control={form.control}
                  name="username"
                  render={({ field }) => (
                    <FormItem>
                      <FormLabel>Användarnamn</FormLabel>
                      <FormControl>
                        <Input placeholder="Användarnamn" {...field} />
                      </FormControl>
                      <FormMessage />
                    </FormItem>
                  )}
                />
                <FormField
                  control={form.control}
                  name="email"
                  render={({ field }) => (
                    <FormItem>
                      <FormLabel>Email</FormLabel>
                      <FormControl>
                        <Input placeholder="Email" {...field} />
                      </FormControl>
                      <FormMessage />
                    </FormItem>
                  )}
                />
                <FormField
                  control={form.control}
                  name="passwordHash"
                  render={({ field }) => (
                    <FormItem>
                      <FormLabel>Password</FormLabel>
                      <FormControl>
                        <Input
                          type="password"
                          placeholder="Lösenord"
                          {...field}
                        />
                      </FormControl>
                      <FormMessage />
                    </FormItem>
                  )}
                />
                <Button type="submit">Skapa</Button>
              </form>
            </Form>
          </CardContent>
        </Card>
      </div>
    </div>
  );
};

export default AddUser;
