import React from 'react'
import '../styles/main.scss'
import { Route, Routes } from 'react-router-dom'
import { Layout } from '../components/Layout/Layout'
import { Articles } from './Articles'
import { Article } from './Article'
import { Default } from './Default'
import { ArticleNew } from './ArticleNew'
import { AuthLayout } from '../components/Layout/AuthLayout'
import { Login } from '../components/Auth/Login/Login'
import { Register } from '../components/Auth/Register/Register'
import { RequireAuth } from '../components/Layout/RequireAuth';

export const Index = () => {
	return (
		<>
			<Routes>
				<Route path='/' element={<Default />} />
				<Route path='/articles' element={<Layout />}>
					<Route index element={<Articles />} />
					<Route path=':id' element={<Article />} />
					<Route path='new' element={<ArticleNew />} />
				</Route>
				<Route path='/auth' element={<AuthLayout />}>
					<Route index element={<RequireAuth />} />
					<Route path='login' element={<Login />} />
					<Route path='register' element={<Register />} />
				</Route>
			</Routes>
		</>
	)
}
