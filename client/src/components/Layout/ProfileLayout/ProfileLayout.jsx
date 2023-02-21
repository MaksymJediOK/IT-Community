import React from 'react'
import styles from './ProfileLayout.module.scss'
import { Container, Grid, Stack } from '@mui/material'
import { Link, Outlet } from 'react-router-dom'
import { Header } from 'components/Header/Header'

export const ProfileLayout = () => {
	return (
		<>
			<Header />
			<Container>
				<Grid container spacing={3}>
					<Grid item xs={8}>
						<div className={styles.title_pr}>Profile</div>
						<div className={styles.container}>
							<Outlet />
						</div>
					</Grid>
					<Grid item xs={4}>
						<Stack sx={{ mt: '32px' }}>
							<div className={styles.title}>Settings</div>
							<Link className={styles.sub} to='/profile'>
								General information
							</Link>
							<Link className={styles.sub} to='/profile/account'>
								Account management
							</Link>
							<Link className={styles.sub} to='/'>
								Contacts
							</Link>
							<Link className={styles.sub} to='/'>
								Connected services
							</Link>
						</Stack>
					</Grid>
				</Grid>
			</Container>
		</>
	)
}
