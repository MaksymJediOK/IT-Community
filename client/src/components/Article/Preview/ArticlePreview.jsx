import React from 'react'
import styles from './ArticlePreview.module.scss'
import { Grid } from '@mui/material'
import FavoriteIcon from '@mui/icons-material/Favorite'
import VisibilityIcon from '@mui/icons-material/Visibility'
import ChatBubbleIcon from '@mui/icons-material/ChatBubble'

export const ArticlePreview = () => {
	return (
		<Grid item xs={6}>
			<div className={styles.container}>
				<img
					className={styles.img_container}
					src='https://www.eea.europa.eu/themes/biodiversity/state-of-nature-in-the-eu/state-of-nature-2020-subtopic/image_print'
					alt='Thumbnail'
				/>
				<div className={styles.inner_container}>
					<div className={styles.author_section}>
						<div className={styles.author_section_text}>Author Name</div>
						<div className={styles.author_section_text}>Sep 12, 2022</div>
					</div>
					<div className={styles.title}>
						Extremely Extremely Very Very Long Long Name for an Article
					</div>
					<div className={styles.tags_container}>
						<div className={styles.tag}>
							<div className={styles.tag_text}>Design</div>
						</div>
						<div className={styles.tag}>
							<div className={styles.tag_text}>Design</div>
						</div>
						<div className={styles.tag}>
							<div className={styles.tag_text}>Design</div>
						</div>
					</div>
					<div className={styles.reactions_container}>
						<div className={styles.reaction_block}>
							<FavoriteIcon sx={{ width: '12px', height: '12px' }} />{' '}
							<span className={styles.reaction_block_number}>5</span>
						</div>
						<div className={styles.reaction_block}>
							<VisibilityIcon sx={{ width: '12px', height: '12px' }} />{' '}
							<span className={styles.reaction_block_number}>5</span>
						</div>
						<div className={styles.reaction_block}>
							<ChatBubbleIcon sx={{ width: '12px', height: '12px' }} />{' '}
							<span className={styles.reaction_block_number}>5</span>
						</div>
					</div>
				</div>
			</div>
		</Grid>
	)
}
