import React from 'react'
import styles from './ItemCard.module.scss'
import FavoriteBorderOutlinedIcon from '@mui/icons-material/FavoriteBorderOutlined'
import ChatBubbleOutlineOutlinedIcon from '@mui/icons-material/ChatBubbleOutlineOutlined'
import VisibilityOutlinedIcon from '@mui/icons-material/VisibilityOutlined'
import BookmarkAddOutlinedIcon from '@mui/icons-material/BookmarkAddOutlined'
import InsertLinkOutlinedIcon from '@mui/icons-material/InsertLinkOutlined'
import MoreHorizOutlinedIcon from '@mui/icons-material/MoreHorizOutlined'

export const ItemCard = () => {
	return (
		<>
			<h5 className={styles.date}>Sep 12, 2022</h5>
			<h2 className={styles.title}>Introducing Business Design Patterns</h2>
			<div className={styles.subtitle}>What they are, their role, and further considerations</div>
			<div className={styles.content_box}>Picture</div>
			<div className={styles.content_box}>article content</div>
			<div className={styles.tag_container}>
				<div className={styles.tag}>
					<div className={styles.tag_text}>Design</div>
				</div>
				<div className={styles.tag}>
					<div className={styles.tag_text}>Design</div>
				</div>
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
			<div className={styles.between_container}>
				<div className={styles.flex_container}>
					<div className={styles.stats_item}>
						<FavoriteBorderOutlinedIcon />
						<div className={styles.stats_item_text}>2,5k</div>
					</div>
					<div className={styles.stats_item}>
						<ChatBubbleOutlineOutlinedIcon />
						<div className={styles.stats_item_text}>2,5k</div>
					</div>
					<div className={styles.stats_item}>
						<VisibilityOutlinedIcon />
						<div className={styles.stats_item_text}>2,5k</div>
					</div>
				</div>
				<div className={styles.share_container}>
					<BookmarkAddOutlinedIcon />
					<InsertLinkOutlinedIcon />
					<MoreHorizOutlinedIcon />
				</div>
			</div>
		</>
	)
}
