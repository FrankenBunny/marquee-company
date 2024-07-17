import {useState} from 'react';
import { useAuthentication } from '../../authcontext/AuthenticationContext';
import { z } from "zod";
import { zodResolver } from '@hookform/resolvers/zod/src/zod.js';
import { SubmitHandler, useForm } from 'react-hook-form';
import { Button } from '../../components/ui/button';
import {
    Form,
    FormControl,
    FormDescription,
    FormField,
    FormItem,
    FormLabel,
    FormMessage,
  } from "../../components/ui/form";
import { Input } from "../../components/ui/input";
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from '../../components/ui/card';


const loginSchema = z.object({
    username: z.string().min(4, {
        message: "Username must be at least 4 characters.",
    }).max(50, {
        message: "Username cannot contain more than 50 characters."
    }).regex(/^[a-z0-9]+$/i, {
        message: "Username may only contain letters A-Z and numbers 1-9."
    }),

    password: z.string().min(10, {
        message: "Password must contain more than 10 characters."
    }).max(100, {
        message: "Password cannot contain more than 100 characters."
    })
})

type LoginSchemaType = z.infer<typeof loginSchema>

const Login = () => {
    const {login} = useAuthentication();

    const form = useForm<z.infer<typeof loginSchema>>({
        resolver: zodResolver(loginSchema),
        defaultValues: {
            username: "",
            password: "",
        }
    })

    const onSubmit: SubmitHandler<LoginSchemaType> = (values) => {
        const adjustedLoginValues = {
            ...values,
            username: values.username.toLowerCase(),
        };

        login(values)
        console.log("Login", adjustedLoginValues)
    }


    return (
        <div className="flex items-center h-screen justify-center bg-marquee_blue-300">
            <Card className="w-[350px]">
                <CardHeader>
                    <CardTitle>Login</CardTitle>
                    <CardDescription>Enter your user credentials here to login and access the web application.</CardDescription>
                </CardHeader>
                <CardContent>
                    <Form {...form}>
                        <form onSubmit={form.handleSubmit(onSubmit)} className="space-y-8">
                            <FormField
                                control={form.control}
                                name="username"
                                render={({ field }) => (
                                    <FormItem>
                                        <FormLabel>Username</FormLabel>
                                        <FormControl>
                                            <Input
                                                style={{textTransform: "lowercase"}}
                                                placeholder="enter your username" 
                                                {...field}
                                            />
                                        </FormControl>
                                        <FormMessage/>
                                    </FormItem>
                                )}
                            />
                            <FormField
                                control={form.control}
                                name="password"
                                render= {({ field }) => (
                                    <FormItem>
                                        <FormLabel>Password</FormLabel>
                                        <FormControl>
                                            <Input type="password" placeholder="enter you password" {...field} />
                                        </FormControl>
                                        <FormMessage/>
                                    </FormItem>
                                )}
                            />
                            <div className='flex justify-between'>
                                <Button variant="secondary" type='submit'>Forgot password?</Button>
                                <Button type='submit'>Login</Button>
                            </div>
                        </form>
                    </Form>
                </CardContent>
            </Card>
        </div>
    );
};

export default Login;