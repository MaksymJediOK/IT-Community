import React, { useState } from 'react'
import styles from './Login.module.scss'
import {
	Button,
	Stack,
	Box,
	TextField,
	FormControl,
	OutlinedInput,
	InputAdornment,
	IconButton,
	Checkbox,
	FormControlLabel,
	Typography,
} from '@mui/material'
import VisibilityOff from '@mui/icons-material/VisibilityOff'
import Visibility from '@mui/icons-material/Visibility'
import { Link, useNavigate } from 'react-router-dom'
import GoogleIcon from '@mui/icons-material/Google'
import { Controller, useForm } from 'react-hook-form'
import { useDispatch } from 'react-redux'
import { useLoginMutation } from '../../../services/authApi'
import { setCredentials } from '../../../store/reducers/authSlice'

export const Login = () => {
	const [showPassword, setShowPassword] = useState(false)
	const [errorMsg, setErrMsg] = useState('')
	const navigate = useNavigate()
	const { handleSubmit, control, reset } = useForm({
		mode: 'onBlur',
	})

	const handleClickShowPassword = () => setShowPassword((show) => !show)

	const handleMouseDownPassword = (event) => {
		event.preventDefault()
	}
	const dispatch = useDispatch()
	const [login] = useLoginMutation()

	const handleOnSubmit = async (data) => {
		try {
			const { key } = await login(data).unwrap()
			dispatch(setCredentials({ accessToken: key, user: { ...data } }))
			reset()
			navigate('/auth')
		} catch (err) {
			const {
				data: { ErrorMessage },
				status,
			} = err
			if (status) {
				setErrMsg(ErrorMessage)
			} else {
				setErrMsg('Login Failed')
			}
		}
	}

	return (
		<div className={styles.container}>
			<div className={styles.auth_container}>
				<div className={styles.title}>Sign in</div>
				<Stack spacing={1} direction='row' alignItems='baseline'>
					<div className={styles.noAccount}> Do not have an account?</div>
					<Link className={styles.reg_link} to='/auth/register'>
						Register
					</Link>
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
				<Box component='form' onSubmit={handleSubmit(handleOnSubmit)}>
					<Stack>
						<Controller
							control={control}
							name='email'
							defaultValue=''
							render={({ field }) => (
								<TextField {...field} fullWidth variant='outlined' label='Email' />
							)}
						/>
						<Stack direction='row' justifyContent='space-between' sx={{ m: '24px 0 8px' }}>
							<div className={styles.password_text}>Password</div>
							<Link to='/' className={styles.forgot_pass}>
								Forgot password?
							</Link>
						</Stack>
						<Controller
							control={control}
							name='password'
							defaultValue=''
							render={({ field }) => (
								<FormControl fullWidth variant='outlined'>
									<OutlinedInput
										{...field}
										id='outlined-adornment-password'
										type={showPassword ? 'text' : 'password'}
										endAdornment={
											<InputAdornment position='end'>
												<IconButton
													aria-label='toggle password visibility'
													onClick={handleClickShowPassword}
													onMouseDown={handleMouseDownPassword}
													edge='end'
												>
													{showPassword ? <VisibilityOff /> : <Visibility />}
												</IconButton>
											</InputAdornment>
										}
									/>
								</FormControl>
							)}
						/>
						<Controller
							control={control}
							name='rememberMe'
							defaultValue={false}
							render={({ field: { value, onChange, ...field } }) => (
								<FormControlLabel
									sx={{ m: '15px 0 18px' }}
									control={<Checkbox onChange={onChange} checked={value} {...field} />}
									label='Remember me?'
								/>
							)}
						/>
					</Stack>
					<Typography sx={{ mb: '10px' }} color='error'>
						{errorMsg ? errorMsg : ''}
					</Typography>
					<Button type='submit' variant='contained' size='large' fullWidth>
						LOG IN
					</Button>
				</Box>
			</div>
		</div>
	)
}
