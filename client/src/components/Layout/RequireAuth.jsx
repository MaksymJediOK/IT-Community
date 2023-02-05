import React from 'react'
import { useTestAuthQuery } from '../../services/authApi'

export const RequireAuth = () => {

	const token = localStorage.getItem('token')
	const { data, isLoading } = useTestAuthQuery()
	console.log(data);
	return (
		<>
			{token === null ? <h1>You have no token</h1> : <h1>You have access</h1>}
		</>
	)
}
