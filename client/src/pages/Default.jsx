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
		</div>
	)
}
