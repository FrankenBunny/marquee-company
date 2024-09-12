import { z } from "zod";
import { zodResolver } from "@hookform/resolvers/zod/src/zod.js";
import { SubmitHandler, useForm } from "react-hook-form";
import { Button } from "@/core/shadcn/button";
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/core/shadcn/form";
import { Card, CardContent, CardHeader, CardTitle } from "@/core/shadcn/card";
import { Input } from "@/core/shadcn/input";
import { useAuthentication } from "./AuthenticationContext";

const loginSchema = z.object({
  username: z
    .string()
    .min(4, {
      message: "Username must be at least 4 characters.",
    })
    .max(50, {
      message: "Username cannot contain more than 50 characters.",
    })
    .regex(/^[a-z0-9]+$/i, {
      message: "Username may only contain letters A-Z and numbers 1-9.",
    }),

  password: z
    .string()
    .min(10, {
      message: "Password must contain more than 10 characters.",
    })
    .max(100, {
      message: "Password cannot contain more than 100 characters.",
    }),
});

type LoginSchemaType = z.infer<typeof loginSchema>;

const Login = () => {
  const { login } = useAuthentication();

  const form = useForm<z.infer<typeof loginSchema>>({
    resolver: zodResolver(loginSchema),
    defaultValues: {
      username: "",
      password: "",
    },
  });

  const onSubmit: SubmitHandler<LoginSchemaType> = (values) => {
    const adjustedLoginValues = {
      ...values,
      username: values.username.toLowerCase(),
    };

    login(values);
    console.log("Login", adjustedLoginValues);
  };

  return (
    <div className="flex items-center h-screen justify-center bg-marquee_blue-300">
      <Card className="w-[350px] bg-marquee_neutral-100">
        <CardHeader>
          <CardTitle className="text-marquee_blue-500">Logga in</CardTitle>
        </CardHeader>
        <CardContent>
          <Form {...form}>
            <form onSubmit={form.handleSubmit(onSubmit)} className="space-y-8">
              <FormField
                control={form.control}
                name="username"
                render={({ field }) => (
                  <FormItem>
                    <FormLabel className="text-marquee_neutral-900">
                      Användarnamn
                    </FormLabel>
                    <FormControl className="text-marquee_red-500">
                      <Input
                        style={{ textTransform: "lowercase" }}
                        placeholder=""
                        {...field}
                      />
                    </FormControl>
                    <FormMessage />
                  </FormItem>
                )}
              />
              <FormField
                control={form.control}
                name="password"
                render={({ field }) => (
                  <FormItem>
                    <FormLabel className="text-marquee_neutral-900">
                      Lösenord
                    </FormLabel>
                    <FormControl className="text-marquee_red-500">
                      <Input
                        className=""
                        type="password"
                        placeholder=""
                        {...field}
                      />
                    </FormControl>
                    <FormMessage />
                  </FormItem>
                )}
              />
              <div className="flex justify-between">
                <Button variant="secondary" type="submit">
                  Forgot password?
                </Button>
                <Button type="submit">Login</Button>
              </div>
            </form>
          </Form>
        </CardContent>
      </Card>
    </div>
  );
};

export default Login;
