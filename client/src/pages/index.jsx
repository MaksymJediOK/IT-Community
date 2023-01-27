import React from 'react'
import '../styles/main.scss'
import { Route, Routes } from 'react-router-dom'
import { Layout } from '../components/Layout/Layout'
import { Articles } from './Articles'
import { Article } from './Article';
import { Default } from './Default';

export const Index = () => {
	return (
		<>
			<Routes>
				<Route path='/' element={<Default />} />
				<Route path='/articles' element={<Layout />}>
					<Route index element={<Articles />} />
					<Route path=':id' element={<Article />} />
					{/*<Route path='new' element={<ArticleDetails />} />*/}
				</Route>
			</Routes>
		</>
	)
}
