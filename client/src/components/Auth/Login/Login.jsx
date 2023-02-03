import React from 'react'
import styles from './Login.module.scss'
import { Button, Stack, TextField } from '@mui/material';
import { Link } from 'react-router-dom'
import styled from '@emotion/styled'
import GoogleIcon from '@mui/icons-material/Google'
import { useForm } from 'react-hook-form'
import Box from '@mui/material/Box'

const RegisterLink = styled(Link)`
	color: #000;
	font-size: 16px;
	line-height: 120%;
	opacity: 0.7;
`

export const Login = () => {
	const {
		register,
		formState: { errors },
		reset,
		handleSubmit,
	} = useForm({
		mode: 'onBlur',
	})

	return (
		<div className={styles.container}>
			<div className={styles.auth_container}>
				<div className={styles.title}>Sign in</div>
				<Stack spacing={1} direction='row' alignItems='baseline'>
					<div className={styles.noAccount}> Do not have an account?</div>
					<RegisterLink to='/auth/register'>Register</RegisterLink>
				</Stack>
				<div className={styles.google}>
					<Stack spacing={1} direction='row' alignItems='center'>
						<GoogleIcon sx={{ width: '16px', height: '16px' }} />
						<div className={styles.google_text}>sign in with google</div>
					</Stack>
				</div>
				<Stack direction='row' spacing={4} alignItems='center' sx={{ margin: '40px 0' }}>
					<div className={styles.line}></div>
					<div className={styles.or_text}>OR</div>
					<div className={styles.line}></div>
				</Stack>
				<form>
					<Stack >

					<TextField
						id='outlined-basic'
						label='Outlined'
						variant='outlined'
						sx={{ mb: '20px' }}
					/>

					<TextField size='small' id='outlined-basic' label='Outlined' variant='outlined' />

						<Button size='medium' sx={{background: '#000', color: 'white'}}>LOG IN</Button>
					</Stack>
				</form>
			</div>
		</div>
	)
}
