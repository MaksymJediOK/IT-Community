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
import { RequireAuth } from '../components/Layout/RequireAuth'
import { Vacancies } from '../components/Vacancy/Vacancies/Vacancies'
import { VacancyDetails } from '../components/Vacancy/VacancyDetails/VacancyDetails'
import { VacanciesApproval } from '../components/Vacancy/VacanciesApproval/VacanciesApproval'
import { ArticleEdit } from '../components/ArticleActions/Edit/ArticleEdit'
import { Account, GeneralProfile } from '../features/Profile'
import { ProfileLayout } from '../components/Layout/ProfileLayout/ProfileLayout'

export const Index = () => {
	return (
		<>
			<Routes>
				<Route path='/' element={<Default />} />
				<Route path='/articles' element={<Layout />}>
					<Route index element={<Articles />} />
					<Route path=':id' element={<Article />} />
					<Route path='new' element={<ArticleNew />} />
					<Route path='edit/:id' element={<ArticleEdit />} />
				</Route>
				<Route path='/vacancies' element={<Layout />}>
					<Route index element={<Vacancies />} />
					<Route path=':id' element={<VacancyDetails />} />
					<Route path='approval' element={<VacanciesApproval />} />
				</Route>
				<Route path='/auth' element={<AuthLayout />}>
					<Route index element={<RequireAuth />} />
					<Route path='login' element={<Login />} />
					<Route path='register' element={<Register />} />
				</Route>
				<Route path='/profile' element={<ProfileLayout />}>
					<Route index element={<GeneralProfile />} />
					<Route path='account' element={<Account />} />
				</Route>
			</Routes>
		</>
	)
}
