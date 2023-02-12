import React from 'react'
import { Link } from 'react-router-dom'

export const Default = () => {
	return (
		<div>
			<Link to='articles'>To articles</Link>
			<br />
			<Link to='articles/1'>Detailed</Link>
			<br />
			<Link to='articles/new'>New/Edit</Link>
			<br />
			<Link to='auth/login'>login</Link>
			<br />
			<Link to='auth/register'>Register</Link>
			<br />
			<Link to='auth'>Auth test</Link>
			<br />
			<Link to='vacancies'>vacancies</Link>
			<br />
			<Link to='vacancies/1'>vacancies Detailed</Link>
		</div>
	)
}
